using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockEntry;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Funcionário", request.SupplierId), false);
            }

            var account = await _dbContext.Users.FindAsync(request.AccountId);
            if (account == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Conta", request.SupplierId), false);
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
            await _dbContext.SaveChangesAsync(cancellationToken);

            foreach (var item in receiving.ReceivedItem)
            {
                var getOrCreateStockCommand = new UpdateProductStockCommand(
                    ProductId: item.ProductId,
                    Quantity: 0,
                    OperationType: StockOperationTypeEnum.None
                );

                var stock = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.ProductId == item.ProductId, cancellationToken);

                if (stock == null)
                {
                    stock = new Domain.Entities.Stock { ProductId = item.ProductId, CurrentQuantity = 0, MinQuantity = 0 };
                    _dbContext.Stocks.Add(stock);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                }

                var updateLotCommand = new UpdateStockLotCommand(
                    StockId: stock.Id,
                    Quantity: item.Quantity,
                    Batch: item.Batch,
                    UnitValue: item.UnitValue,
                    ExpiryDate: item.ExpiryDate,
                    SourceDocumentId: receiving.Id,
                    SourceDocumentType: nameof(Receiving)
                );

                var lotResult = await _mediator.Send(updateLotCommand, cancellationToken);
                if (!lotResult.Success || lotResult.Data == null)
                {
                    return new ApiResponse<ReceivingDto>(lotResult.StatusCode, lotResult.Message, false);
                }

                var stockLot = lotResult.Data;

                var updateStockCommand = new UpdateProductStockCommand(
                    ProductId: item.ProductId,
                    Quantity: item.Quantity,
                    OperationType: StockOperationTypeEnum.Receipt
                );
                await _mediator.Send(updateStockCommand, cancellationToken);

                var createMovementCommand = new CreateStockEntryCommand(
                    ProductId: item.ProductId,
                    Quantity: item.Quantity,
                    StockLotId: stockLot.Id,
                    SourceDocumentId: receiving.Id,
                    SourceDocumentType: "Receiving",
                    ResponsibleId: receiving.ResponsibleId
                );
                await _mediator.Send(createMovementCommand, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);
            return new ApiResponse<ReceivingDto>(StatusCodes.Status201Created, ApiMessages.ReceivingAndStockMovementsCreatedSuccessfully, receivingDto);
        }
    }
}
