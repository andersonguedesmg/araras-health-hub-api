using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost;
using ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockMovement;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateDispenseReturn
{
    public class CreateDispenseReturnCommandHandler : IRequestHandler<CreateDispenseReturnCommand, ApiResponseO<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IOrderRepository _orderRepo;

        public CreateDispenseReturnCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator,
            IOrderRepository orderRepo)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
            _orderRepo = orderRepo;
        }

        public async Task<ApiResponseO<int>> Handle(CreateDispenseReturnCommand request, CancellationToken cancellationToken)
        {
            var originalOrder = await _orderRepo.GetByIdAsync(request.OriginalOrderId, cancellationToken);
            if (originalOrder == null)
            {
                return new ApiResponseO<int>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Pedido Original", request.OriginalOrderId), 0);
            }

            if (originalOrder.OrderStatusId != (int)OrderStatusEnum.Completed)
            {
                return new ApiResponseO<int>(StatusCodes.Status400BadRequest, ApiMessages.CannotReturnFromOrderInStatus(((OrderStatusEnum)originalOrder.OrderStatusId).ToString()), 0);
            }

            var newDispenseReturn = new DispenseReturn
            {
                OriginalOrderId = request.OriginalOrderId,
                Reason = request.Reason,
                ReturnedByEmployeeId = request.ReturnedByEmployeeId,
                ReturnedByAccountId = request.ReturnedByAccountId,
                ReturnDate = DateTime.UtcNow,
            };

            var responsible = await _dbContext.Employees.FindAsync(request.ReturnedByEmployeeId);
            if (responsible == null)
            {
                return new ApiResponseO<int>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Responsável pela Devolução", request.ReturnedByEmployeeId), 0);
            }
            newDispenseReturn.ReturnedByEmployee = responsible;

            decimal totalReturnedValue = 0;
            var newReturnItems = new List<DispenseReturnItem>();

            foreach (var itemCommand in request.ReturnItems)
            {
                if (itemCommand.Quantity <= 0)
                    throw new ArgumentException($"A quantidade do item {itemCommand.ProductId} deve ser positiva.");
                if (itemCommand.UnitValue <= 0)
                    throw new ArgumentException($"O valor unitário do item {itemCommand.ProductId} deve ser positivo.");

                var product = await _dbContext.Products.FindAsync(itemCommand.ProductId);
                if (product == null)
                {
                    throw new ApplicationException(ApiMessages.NotFoundWithId("Produto", itemCommand.ProductId));
                }

                var returnItem = _mapper.Map<DispenseReturnItem>(itemCommand);
                returnItem.TotalValue = itemCommand.Quantity * itemCommand.UnitValue;
                newReturnItems.Add(returnItem);
                totalReturnedValue += returnItem.TotalValue;

                var updateStockCommand = new UpdateProductStockCommand(
                    ProductId: itemCommand.ProductId,
                    Quantity: itemCommand.Quantity,
                    OperationType: StockOperationTypeEnum.Return
                );
                var stockResult = await _mediator.Send(updateStockCommand, cancellationToken);

                if (!stockResult.Success || stockResult.Data == null)
                {
                    throw new InvalidOperationException($"Falha ao atualizar o estoque consolidado para o produto {itemCommand.ProductId}. Erro: {stockResult.Message}");
                }
                var updatedStock = stockResult.Data;

                var updateLotCommand = new UpdateStockLotCommand(
                    StockId: updatedStock.Id,
                    Quantity: itemCommand.Quantity,
                    Batch: itemCommand.Batch,
                    Brand: itemCommand.Brand,
                    UnitValue: itemCommand.UnitValue,
                    ExpiryDate: itemCommand.ExpiryDate,
                    SourceDocumentId: 0,
                    SourceDocumentType: nameof(DispenseReturn)
                );
                var lotResult = await _mediator.Send(updateLotCommand, cancellationToken);

                if (!lotResult.Success || lotResult.Data == null)
                {
                    throw new InvalidOperationException($"Falha ao atualizar o lote para o produto {itemCommand.ProductId}. Erro: {lotResult.Message}");
                }
                var stockLot = lotResult.Data;

                var updateCostCommand = new UpdateStockAverageCostCommand(
                    StockId: updatedStock.Id,
                    EntryQuantity: itemCommand.Quantity,
                    EntryUnitValue: itemCommand.UnitValue,
                    UpdatedStockQuantity: updatedStock.CurrentQuantity
                );
                var costResult = await _mediator.Send(updateCostCommand, cancellationToken);

                if (!costResult.Success)
                {
                    throw new InvalidOperationException($"Falha ao recalcular o CMP para o produto {itemCommand.ProductId}. Erro: {costResult.Message}");
                }

                returnItem.StockLotId = stockLot.Id;
                returnItem.StockLot = null!;
            }

            newDispenseReturn.TotalReturnedValue = totalReturnedValue;
            newDispenseReturn.ReturnItems = newReturnItems;

            await _dbContext.DispenseReturns.AddAsync(newDispenseReturn, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            foreach (var item in newDispenseReturn.ReturnItems)
            {
                var createMovementCommand = new CreateStockMovementCommand(
                    ProductId: item.ProductId,
                    Quantity: item.Quantity,
                    StockLotId: item.StockLotId,
                    SourceDocumentId: newDispenseReturn.Id,
                    SourceDocumentType: nameof(DispenseReturn),
                    ResponsibleId: newDispenseReturn.ReturnedByEmployeeId,
                    MovementType: MovementTypeEnum.Entry,
                    MovementCost: item.TotalValue,
                    MovementDate: newDispenseReturn.ReturnDate
                );
                await _mediator.Send(createMovementCommand, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);


            return new ApiResponseO<int>(
                StatusCodes.Status201Created,
                ApiMessages.DispenseReturnRecordedSuccessfully,
                newDispenseReturn.Id
            );
        }
    }
}
