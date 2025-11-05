using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost;
using ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces;
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
        private readonly IProductRepository _productRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockMovementRepository _stockMovementRepo;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IStockLotRepository _stockLotRepo;
        private readonly IStockCostRepository _stockCostRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateStockAdjustmentCommandHandler(
            IProductRepository productRepo,
            IEmployeeRepository employeeRepo,
            IStockMovementRepository stockMovementRepo,
            IStockAdjustmentRepository stockAdjustmentRepo,
            IStockRepository stockRepo,
            IStockLotRepository stockLotRepo,
            IStockCostRepository stockCostRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator)
        {
            _productRepo = productRepo;
            _employeeRepo = employeeRepo;
            _stockMovementRepo = stockMovementRepo;
            _stockAdjustmentRepo = stockAdjustmentRepo;
            _stockRepo = stockRepo;
            _stockLotRepo = stockLotRepo;
            _stockCostRepository = stockCostRepository;
            _unitOfWork = unitOfWork;
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

            await _stockAdjustmentRepo.AddAsync(adjustment);
            await _unitOfWork.CommitAsync();

            var newMovements = new List<StockMovement>();
            var isNegativeAdjustment = request.Type == StockAdjustmentType.Negative;

            foreach (var itemCommand in request.AdjustmentItems)
            {
                var product = await _productRepo.GetByIdAsync(itemCommand.ProductId);
                if (product == null)
                {
                    return new ApiResponse<int>(StatusCodes.Status404NotFound, ApiMessages.NotFound($"Produto com ID {itemCommand.ProductId}"), 0);
                }

                var stock = await _stockRepo.GetByProductIdAsync(itemCommand.ProductId);
                if (stock == null)
                {
                    if (isNegativeAdjustment)
                        return new ApiResponse<int>(StatusCodes.Status404NotFound, ApiMessages.NotFound($"Estoque consolidado para o Produto {itemCommand.ProductId}"), 0);

                    stock = new Stock { ProductId = itemCommand.ProductId, CurrentQuantity = 0, MinQuantity = 0 };
                    await _stockRepo.AddAsync(stock);
                }

                int stockLotId;
                var movementQuantity = Math.Abs(itemCommand.Quantity);
                decimal movementCost = 0M;
                decimal averageUnitCost = 0M;

                var adjustmentItem = new StockAdjustmentItem
                {
                    StockAdjustmentId = adjustment.Id,
                    ProductId = itemCommand.ProductId,
                    Quantity = itemCommand.Quantity,
                    Batch = itemCommand.Batch,
                    ExpiryDate = itemCommand.ExpiryDate,
                };

                var stockCost = await _stockCostRepository.GetByStockIdAsync(stock.Id);
                averageUnitCost = stockCost?.AverageUnitCost ?? 0M;

                if (isNegativeAdjustment)
                {
                    if (!itemCommand.StockLotId.HasValue)
                    {
                        throw new ArgumentException("Ajustes negativos exigem a especificação do Lote (StockLotId) para dar baixa.");
                    }
                    stockLotId = itemCommand.StockLotId.Value;

                    var lot = await _stockLotRepo.GetByIdAsync(stockLotId);
                    if (lot == null || lot.AvailableQuantity < movementQuantity)
                    {
                        throw new ApplicationException($"Lote {stockLotId} insuficiente ou não encontrado para o ajuste de saída.");
                    }

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
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(itemCommand.Batch) || !itemCommand.ExpiryDate.HasValue || !itemCommand.UnitValue.HasValue)
                    {
                        throw new ArgumentException("Ajustes positivos exigem Lote, Data de Validade e Valor Unitário.");
                    }

                    decimal unitValue = itemCommand.UnitValue.Value;
                    movementCost = movementQuantity * unitValue;

                    var updateLotCommand = new UpdateStockLotCommand(
                        StockId: stock.Id,
                        Quantity: movementQuantity,
                        Batch: itemCommand.Batch!,
                        UnitValue: unitValue,
                        ExpiryDate: itemCommand.ExpiryDate.Value,
                        SourceDocumentId: adjustment.Id,
                        SourceDocumentType: nameof(StockAdjustment)
                    );
                    var lotResult = await _mediator.Send(updateLotCommand, cancellationToken);
                    if (!lotResult.Success)
                    {
                        return new ApiResponse<int>(StatusCodes.Status500InternalServerError, lotResult.Message, 0);
                    }
                    stockLotId = lotResult.Data!.Id;

                    var updateCostCommand = new UpdateStockAverageCostCommand(
                        StockId: stock.Id,
                        EntryQuantity: movementQuantity,
                        EntryUnitValue: unitValue,
                        UpdatedStockQuantity: stock.CurrentQuantity
                    );
                    await _mediator.Send(updateCostCommand, cancellationToken);

                    adjustmentItem.UnitValue = unitValue;
                    adjustmentItem.Batch = itemCommand.Batch;
                    adjustmentItem.ExpiryDate = itemCommand.ExpiryDate;
                }

                adjustmentItem.StockLotId = stockLotId;
                adjustment.AdjustmentItems.Add(adjustmentItem);

                var quantityChange = isNegativeAdjustment ? -movementQuantity : movementQuantity;
                newMovements.Add(new StockMovement
                {
                    StockLotId = stockLotId,
                    Quantity = quantityChange,
                    Type = isNegativeAdjustment ? MovementTypeEnum.Exit : MovementTypeEnum.Entry,
                    SourceDocumentId = adjustment.Id,
                    SourceDocumentType = nameof(StockAdjustment),
                    ResponsibleId = request.ResponsibleId,
                    MovementCost = movementCost
                });

                var updateStockCommand = new UpdateProductStockCommand(
                    itemCommand.ProductId,
                    quantityChange,
                    StockOperationTypeEnum.Adjustment
                );
                await _mediator.Send(updateStockCommand, cancellationToken);
            }

            _stockAdjustmentRepo.UpdateWithoutSaving(adjustment);
            await _stockMovementRepo.AddRangeAsync(newMovements);

            await _unitOfWork.CommitAsync();

            return new ApiResponse<int>(StatusCodes.Status200OK, ApiMessages.StockAdjustmentCompletedSuccessfully, adjustment.Id);
        }
    }
}
