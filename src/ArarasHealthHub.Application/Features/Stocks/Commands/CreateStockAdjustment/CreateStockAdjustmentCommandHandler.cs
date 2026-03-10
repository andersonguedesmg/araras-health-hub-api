using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost;
using ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockMovement;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment
{
    public class CreateStockAdjustmentCommandHandler : IRequestHandler<CreateStockAdjustmentCommand, ApiResponseO<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateStockAdjustmentCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ApiResponseO<int>> Handle(CreateStockAdjustmentCommand request, CancellationToken cancellationToken)
        {
            // var adjustment = _mapper.Map<StockAdjustment>(request);
            // bool isPositiveAdjustment = request.Type == StockAdjustmentType.Positive;

            // adjustment.Responsible = await _dbContext.Employees.FindAsync(request.ResponsibleId);
            // if (adjustment.Responsible == null)
            // {
            //     return new ApiResponseO<int>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Responsável", request.ResponsibleId), 0);
            // }

            // decimal totalAdjustmentValue = 0;
            // var newAdjustmentItems = new List<StockAdjustmentItem>();

            // foreach (var itemCommand in request.AdjustmentItems)
            // {
            //     var product = await _dbContext.Products.FindAsync(itemCommand.ProductId);
            //     if (product == null)
            //     {
            //         throw new ApplicationException(ApiMessages.NotFoundWithId("Produto", itemCommand.ProductId));
            //     }

            //     if (string.IsNullOrWhiteSpace(itemCommand.Batch))
            //         throw new ArgumentException($"O Lote (Batch) é obrigatório para Ajustes (Produto {itemCommand.ProductId}).");

            //     if (isPositiveAdjustment)
            //     {
            //         if (!itemCommand.ExpiryDate.HasValue || !itemCommand.UnitValue.HasValue)
            //             throw new ArgumentException($"Ajustes positivos exigem Data de Validade e Valor Unitário para o Produto {itemCommand.ProductId}.");
            //     }

            //     var itemQuantity = itemCommand.Quantity;

            //     var adjustmentItem = new StockAdjustmentItem
            //     {
            //         ProductId = itemCommand.ProductId,
            //         Quantity = isPositiveAdjustment ? itemQuantity : -itemQuantity,
            //         UnitValue = itemCommand.UnitValue,
            //         Batch = itemCommand.Batch!,
            //         Brand = itemCommand.Brand,
            //         ExpiryDate = itemCommand.ExpiryDate,
            //         TotalValue = isPositiveAdjustment ? itemQuantity * itemCommand.UnitValue!.Value : null,
            //         Product = null!
            //     };

            //     newAdjustmentItems.Add(adjustmentItem);

            //     totalAdjustmentValue += adjustmentItem.TotalValue ?? 0M;
            // }

            // adjustment.AdjustmentItems = newAdjustmentItems;

            // await _dbContext.StockAdjustments.AddAsync(adjustment, cancellationToken);

            // await _dbContext.SaveChangesAsync(cancellationToken);

            // foreach (var item in adjustment.AdjustmentItems)
            // {
            //     decimal quantityChange = item.Quantity > 0 ? item.Quantity : item.Quantity * -1;
            //     decimal finalMovementCost = 0M;
            //     StockLot? stockLot = null;

            //     var stockOperationType = isPositiveAdjustment ? StockOperationTypeEnum.Adjustment : StockOperationTypeEnum.Dispatch;

            //     var updateStockCommand = new UpdateProductStockCommand(
            //         ProductId: item.ProductId,
            //         Quantity: quantityChange,
            //         OperationType: stockOperationType
            //     );
            //     var stockResult = await _mediator.Send(updateStockCommand, cancellationToken);

            //     if (!stockResult.Success || stockResult.Data == null)
            //     {
            //         throw new InvalidOperationException($"Falha ao atualizar o estoque consolidado para o produto {item.ProductId}. Erro: {stockResult.Message}");
            //     }
            //     var updatedStock = stockResult.Data;

            //     if (isPositiveAdjustment)
            //     {
            //         var updateLotCommand = new UpdateStockLotCommand(
            //             StockId: updatedStock.Id,
            //             Quantity: quantityChange,
            //             Batch: item.Batch!,
            //             Brand: item.Brand!,
            //             UnitValue: item.UnitValue!.Value,
            //             ExpiryDate: item.ExpiryDate!.Value,
            //             SourceDocumentId: adjustment.Id,
            //             SourceDocumentType: nameof(StockAdjustment)
            //         );
            //         var lotResult = await _mediator.Send(updateLotCommand, cancellationToken);

            //         if (!lotResult.Success || lotResult.Data == null)
            //         {
            //             throw new InvalidOperationException($"Falha ao atualizar o lote para o produto {item.ProductId}. Erro: {lotResult.Message}");
            //         }

            //         stockLot = lotResult.Data;
            //         finalMovementCost = quantityChange * item.UnitValue!.Value;

            //         var updateCostCommand = new UpdateStockAverageCostCommand(
            //             StockId: updatedStock.Id,
            //             EntryQuantity: quantityChange,
            //             EntryUnitValue: item.UnitValue!.Value,
            //             UpdatedStockQuantity: updatedStock.CurrentQuantity
            //         );
            //         var costResult = await _mediator.Send(updateCostCommand, cancellationToken);

            //         if (!costResult.Success)
            //         {
            //             throw new InvalidOperationException($"Falha ao recalcular o CMP para o produto {item.ProductId}. Erro: {costResult.Message}");
            //         }

            //         item.TotalValue = finalMovementCost;
            //     }
            //     else
            //     {
            //         stockLot = await _dbContext.StockLots
            //             .FirstOrDefaultAsync(sl =>
            //                 sl.StockId == updatedStock.Id &&
            //                 sl.Batch == item.Batch &&
            //                 sl.Brand == item.Brand,
            //                 cancellationToken
            //             );

            //         if (stockLot == null)
            //         {
            //             throw new ApplicationException($"Lote {item.Batch} não encontrado para o Produto {item.ProductId} para ajuste negativo.");
            //         }

            //         var stockCost = await _dbContext.StockCosts.FirstOrDefaultAsync(sc => sc.StockId == updatedStock.Id, cancellationToken);

            //         if (stockCost == null)
            //         {
            //             stockCost = new StockCost
            //             {
            //                 StockId = updatedStock.Id,
            //                 AverageUnitCost = 0M,
            //                 CurrentTotalCost = 0M
            //             };
            //             _dbContext.StockCosts.Add(stockCost);

            //             await _dbContext.SaveChangesAsync(cancellationToken);
            //         }

            //         decimal averageUnitCost = stockCost.AverageUnitCost;
            //         finalMovementCost = quantityChange * averageUnitCost;

            //         stockLot.RemoveQuantity(quantityChange);
            //         _dbContext.StockLots.Update(stockLot);
            //         await _dbContext.SaveChangesAsync(cancellationToken);

            //         stockCost.CurrentTotalCost -= finalMovementCost;

            //         if (updatedStock.CurrentQuantity > 0)
            //         {
            //             stockCost.AverageUnitCost = stockCost.CurrentTotalCost / updatedStock.CurrentQuantity;
            //         }
            //         else
            //         {
            //             stockCost.AverageUnitCost = 0M;
            //         }

            //         _dbContext.StockCosts.Update(stockCost);
            //         await _dbContext.SaveChangesAsync(cancellationToken);

            //         item.UnitValue = averageUnitCost;
            //         item.ExpiryDate = stockLot.ExpiryDate;
            //         item.TotalValue = finalMovementCost * -1;
            //     }

            //     var createMovementCommand = new CreateStockMovementCommand(
            //         ProductId: item.ProductId,
            //         Quantity: quantityChange,
            //         StockLotId: stockLot!.Id,
            //         SourceDocumentId: adjustment.Id,
            //         SourceDocumentType: nameof(StockAdjustment),
            //         ResponsibleId: adjustment.ResponsibleId,
            //         MovementType: isPositiveAdjustment ? MovementTypeEnum.Entry : MovementTypeEnum.Exit,
            //         MovementCost: finalMovementCost,
            //         MovementDate: adjustment.AdjustmentDate
            //     );
            //     await _mediator.Send(createMovementCommand, cancellationToken);

            //     item.StockLotId = stockLot!.Id;
            //     item.StockLot = null;
            // }

            return new ApiResponseO<int>(StatusCodes.Status201Created, ApiMessages.StockAdjustmentCompletedSuccessfully, null!); //adjustment.Id
        }
    }
}
