using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost;
using ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockMovement;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving
{
    public class CreateReceivingCommandHandler : IRequestHandler<CreateReceivingCommand, ApiResponse<ReceivingDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateReceivingCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ApiResponse<ReceivingDto>> Handle(CreateReceivingCommand request, CancellationToken cancellationToken)
        {
            var receiving = _mapper.Map<Receiving>(request);

            receiving.Supplier = await _dbContext.Suppliers.FindAsync(request.SupplierId);
            if (receiving.Supplier == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Fornecedor", request.SupplierId), false);
            }

            receiving.Responsible = await _dbContext.Employees.FindAsync(request.ResponsibleId);
            if (receiving.Responsible == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Funcionário", request.ResponsibleId), false);
            }

            var account = await _dbContext.Users.FindAsync(request.AccountId);
            if (account == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Conta", request.AccountId), false);
            }

            decimal totalCalculatedValue = 0;
            var newReceivedItems = new List<ReceivedItem>();

            foreach (var itemCommand in request.ReceivedItems)
            {
                var product = await _dbContext.Products.FindAsync(itemCommand.ProductId);
                if (product == null)
                {
                    return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"{ApiMessages.NotFoundWithId("Produto", itemCommand.ProductId)} para o item.", false);
                }

                var receivedItems = _mapper.Map<ReceivedItem>(itemCommand);
                receivedItems.Product = product;
                receivedItems.TotalValue = receivedItems.Quantity * receivedItems.UnitValue;

                newReceivedItems.Add(receivedItems);
                totalCalculatedValue += receivedItems.TotalValue;
            }

            receiving.ReceivedItem = newReceivedItems;
            receiving.TotalValue = totalCalculatedValue;

            await _dbContext.Receivings.AddAsync(receiving, cancellationToken);

            foreach (var item in receiving.ReceivedItem)
            {
                var updateStockCommand = new UpdateProductStockCommand(
                    ProductId: item.ProductId,
                    Quantity: item.Quantity,
                    OperationType: StockOperationTypeEnum.Receipt
                );
                var stockResult = await _mediator.Send(updateStockCommand, cancellationToken);

                if (!stockResult.Success || stockResult.Data == null)
                {
                    throw new InvalidOperationException($"Falha ao atualizar o estoque consolidado para o produto {item.ProductId}. Erro: {stockResult.Message}");
                }

                var updatedStock = stockResult.Data;

                var updateLotCommand = new UpdateStockLotCommand(
                    StockId: updatedStock.Id,
                    Quantity: item.Quantity,
                    Batch: item.Batch,
                    Brand: item.Brand,
                    UnitValue: item.UnitValue,
                    ExpiryDate: item.ExpiryDate,
                    SourceDocumentId: receiving.Id,
                    SourceDocumentType: nameof(Receiving)
                );
                var lotResult = await _mediator.Send(updateLotCommand, cancellationToken);

                if (!lotResult.Success || lotResult.Data == null)
                {
                    throw new InvalidOperationException($"Falha ao atualizar o lote para o produto {item.ProductId}. Erro: {lotResult.Message}");
                }

                var stockLot = lotResult.Data;

                var updateCostCommand = new UpdateStockAverageCostCommand(
                    StockId: updatedStock.Id,
                    EntryQuantity: item.Quantity,
                    EntryUnitValue: item.UnitValue,
                    UpdatedStockQuantity: updatedStock.CurrentQuantity
                );
                var costResult = await _mediator.Send(updateCostCommand, cancellationToken);

                if (!costResult.Success)
                {
                    throw new InvalidOperationException($"Falha ao recalcular o CMP para o produto {item.ProductId}. Erro: {costResult.Message}");
                }

                var createMovementCommand = new CreateStockMovementCommand(
                    ProductId: item.ProductId,
                    Quantity: item.Quantity,
                    StockLotId: stockLot.Id,
                    SourceDocumentId: receiving.Id,
                    SourceDocumentType: nameof(Receiving),
                    ResponsibleId: receiving.ResponsibleId,
                    MovementType: MovementTypeEnum.Entry,
                    MovementCost: item.UnitValue * item.Quantity,
                    MovementDate: receiving.ReceivingDate
                );
                await _mediator.Send(createMovementCommand, cancellationToken);
            }

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);

            return new ApiResponse<ReceivingDto>(StatusCodes.Status201Created, ApiMessages.ReceivingAndStockMovementsCreatedSuccessfully, receivingDto);
        }
    }
}
