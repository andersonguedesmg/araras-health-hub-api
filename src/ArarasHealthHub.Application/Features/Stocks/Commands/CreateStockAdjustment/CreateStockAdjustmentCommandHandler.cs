using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost;
using ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockMovement;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment
{
    public class CreateStockAdjustmentCommandHandler : IRequestHandler<CreateStockAdjustmentCommand, ApiResponse<int>>
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IStockLotRepository _stockLotRepo;
        private readonly IStockCostRepository _stockCostRepository;
        private readonly IMediator _mediator;

        public CreateStockAdjustmentCommandHandler(
            IEmployeeRepository employeeRepo,
            IStockAdjustmentRepository stockAdjustmentRepo,
            IStockRepository stockRepo,
            IStockLotRepository stockLotRepo,
            IStockCostRepository stockCostRepository,
            IMediator mediator)
        {
            _employeeRepo = employeeRepo;
            _stockAdjustmentRepo = stockAdjustmentRepo;
            _stockRepo = stockRepo;
            _stockLotRepo = stockLotRepo;
            _stockCostRepository = stockCostRepository;
            _mediator = mediator;
        }

        public async Task<ApiResponse<int>> Handle(CreateStockAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var responsible = await _employeeRepo.GetByIdAsync(request.ResponsibleId);
            if (responsible == null)
            {
                return new ApiResponse<int>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), 0);
            }

            var adjustment = new StockAdjustment
            {
                Type = request.Type,
                Reason = request.Reason,
                Observation = request.Observation,
                AdjustmentDate = DateTime.UtcNow,
                ResponsibleId = request.ResponsibleId,
                AccountId = request.AccountId,
            };

            await _stockAdjustmentRepo.AddWithoutSavingAsync(adjustment);

            var isNegativeAdjustment = request.Type == StockAdjustmentType.Negative;

            foreach (var itemCommand in request.AdjustmentItems)
            {
                var stock = await _stockRepo.GetByProductIdAsync(itemCommand.ProductId);

                if (stock == null)
                {
                    if (isNegativeAdjustment)
                        throw new ApplicationException($"Estoque consolidado para o Produto {itemCommand.ProductId} não encontrado para ajuste de saída.");

                    var newStockCommand = new UpdateProductStockCommand(
                        ProductId: itemCommand.ProductId,
                        Quantity: 0,
                        OperationType: StockOperationTypeEnum.Adjustment
                    );
                    var stockResult = await _mediator.Send(newStockCommand, cancellationToken);
                    if (!stockResult.Success) throw new ApplicationException(stockResult.Message);
                    stock = stockResult.Data;
                }

                var movementQuantity = Math.Abs(itemCommand.Quantity);
                decimal movementCost;
                int stockLotId;
                decimal unitValue;

                var adjustmentItem = new StockAdjustmentItem
                {
                    StockAdjustmentId = adjustment.Id,
                    ProductId = itemCommand.ProductId,
                    Quantity = isNegativeAdjustment ? -movementQuantity : movementQuantity,
                    Batch = itemCommand.Batch,
                    ExpiryDate = itemCommand.ExpiryDate,
                };

                if (isNegativeAdjustment)
                {
                    if (string.IsNullOrWhiteSpace(itemCommand.Batch))
                    {
                        throw new ArgumentException("Ajustes negativos exigem o número do Lote (Batch) para dar baixa.");
                    }

                    var lot = await _stockLotRepo.GetByStockIdAndBatchAsync(stock!.Id, itemCommand.Batch!);

                    if (lot == null)
                    {
                        throw new ApplicationException($"Lote {itemCommand.Batch} não encontrado para o Produto {itemCommand.ProductId} para o ajuste de saída.");
                    }

                    if (lot.AvailableQuantity < movementQuantity)
                    {
                        throw new ApplicationException($"Lote {itemCommand.Batch} (ID: {lot.Id}) possui saldo insuficiente ({lot.AvailableQuantity}) para o ajuste de saída de {movementQuantity}.");
                    }

                    stockLotId = lot.Id;

                    var stockCost = await _stockCostRepository.GetByStockIdAsync(stock.Id);
                    decimal averageUnitCost = stockCost?.AverageUnitCost ?? 0M;

                    unitValue = lot.UnitValue;
                    movementCost = movementQuantity * averageUnitCost;

                    lot.RemoveQuantity(movementQuantity);
                    _stockLotRepo.UpdateWithoutSaving(lot);

                    if (stockCost != null)
                    {
                        stockCost.CurrentTotalCost -= movementCost;
                        _stockCostRepository.UpdateWithoutSaving(stockCost);
                    }

                    adjustmentItem.UnitValue = lot.UnitValue;
                    adjustmentItem.Batch = lot.Batch;
                    adjustmentItem.ExpiryDate = lot.ExpiryDate;

                    var updateStockCommand = new UpdateProductStockCommand(
                        itemCommand.ProductId,
                        -movementQuantity,
                        StockOperationTypeEnum.Adjustment
                    );
                    await _mediator.Send(updateStockCommand, cancellationToken);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(itemCommand.Batch) || !itemCommand.ExpiryDate.HasValue || !itemCommand.UnitValue.HasValue)
                        throw new ArgumentException("Ajustes positivos exigem Lote, Data de Validade e Valor Unitário.");

                    unitValue = itemCommand.UnitValue.Value;
                    movementCost = movementQuantity * unitValue;

                    var updateLotCommand = new UpdateStockLotCommand(
                        StockId: stock!.Id,
                        Quantity: movementQuantity,
                        Batch: itemCommand.Batch!,
                        UnitValue: unitValue,
                        ExpiryDate: itemCommand.ExpiryDate.Value,
                        SourceDocumentId: adjustment.Id,
                        SourceDocumentType: nameof(StockAdjustment)
                    );
                    var lotResult = await _mediator.Send(updateLotCommand, cancellationToken);
                    if (!lotResult.Success) throw new ApplicationException(lotResult.Message);
                    stockLotId = lotResult.Data!.Id;

                    var updateStockBeforeCostCommand = new UpdateProductStockCommand(
                        itemCommand.ProductId,
                        movementQuantity,
                        StockOperationTypeEnum.Adjustment
                    );
                    var stockUpdateResult = await _mediator.Send(updateStockBeforeCostCommand, cancellationToken);
                    if (!stockUpdateResult.Success) throw new ApplicationException(stockUpdateResult.Message);
                    var updatedStock = stockUpdateResult.Data;

                    var updateCostCommand = new UpdateStockAverageCostCommand(
                        StockId: updatedStock!.Id,
                        EntryQuantity: movementQuantity,
                        EntryUnitValue: unitValue,
                        UpdatedStockQuantity: updatedStock.CurrentQuantity
                    );
                    await _mediator.Send(updateCostCommand, cancellationToken);

                    adjustmentItem.UnitValue = unitValue;
                    adjustmentItem.Batch = itemCommand.Batch;
                    adjustmentItem.ExpiryDate = itemCommand.ExpiryDate;
                }

                adjustmentItem.TotalValue = movementQuantity * adjustmentItem.UnitValue!.Value;
                adjustmentItem.StockLotId = stockLotId;
                adjustment.AdjustmentItems.Add(adjustmentItem);

                var movementType = isNegativeAdjustment ? MovementTypeEnum.Exit : MovementTypeEnum.Entry;
                var createMovementCommand = new CreateStockMovementCommand(
                    ProductId: itemCommand.ProductId,
                    Quantity: isNegativeAdjustment ? -movementQuantity : movementQuantity,
                    StockLotId: stockLotId,
                    SourceDocumentId: adjustment.Id,
                    SourceDocumentType: nameof(StockAdjustment),
                    ResponsibleId: request.ResponsibleId,
                    MovementType: movementType,
                    MovementCost: movementCost
                );
                await _mediator.Send(createMovementCommand, cancellationToken);
            }

            return new ApiResponse<int>(StatusCodes.Status200OK, ApiMessages.StockAdjustmentCompletedSuccessfully, adjustment.Id);
        }
    }
}
