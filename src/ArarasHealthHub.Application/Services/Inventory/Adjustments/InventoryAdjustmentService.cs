using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Adjustments;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Costs;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Lots;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Movements;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Services.Inventory.Adjustments
{
    public class InventoryAdjustmentService : IInventoryAdjustmentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IInventoryLotService _inventoryLotService;
        private readonly IInventoryCostService _inventoryCostService;
        private readonly IInventoryMovementService _inventoryMovementService;

        public InventoryAdjustmentService(
            IApplicationDbContext dbContext,
            IInventoryLotService inventoryLotService,
            IInventoryCostService inventoryCostService,
            IInventoryMovementService inventoryMovementService)
        {
            _dbContext = dbContext;
            _inventoryLotService = inventoryLotService;
            _inventoryCostService = inventoryCostService;
            _inventoryMovementService = inventoryMovementService;
        }

        public async Task<Result<int>> CreateAdjustmentAsync(
            CreateStockAdjustmentCommand command,
            CancellationToken cancellationToken)
        {
            var adjustment = new StockAdjustment(
                type: command.Type,
                reason: command.Reason,
                adjustmentDate: command.AdjustmentDate,
                responsibleId: command.ResponsibleId,
                accountId: command.AccountId,
                observation: command.Observation);

            foreach (var itemCommand in command.Items)
            {
                var stock = await _dbContext.Stocks
                    .Include(x => x.StockCost)
                    .Include(x => x.Lots)
                    .FirstOrDefaultAsync(x => x.ProductId == itemCommand.ProductId, cancellationToken);

                if (stock is null)
                {
                    throw new DomainException(
                        $"Estoque do produto {itemCommand.ProductId} não encontrado."
                    );
                }

                var isEntry = command.Type == StockAdjustmentType.Entry;

                if (isEntry)
                {
                    stock.IncreaseStock(itemCommand.Quantity);

                    var stockLot = await _inventoryLotService.GetOrCreateLotAsync(
                        stock: stock,
                        batch: itemCommand.Batch,
                        brand: itemCommand.Brand,
                        unitValue: itemCommand.UnitValue!.Value,
                        expiryDate: itemCommand.ExpiryDate!.Value,
                        quantity: itemCommand.Quantity,
                        receivedItemId: null,
                        cancellationToken: cancellationToken);

                    _inventoryCostService.ProcessEntryCost(
                        stock,
                        itemCommand.Quantity,
                        itemCommand.UnitValue.Value);

                    await _inventoryMovementService.CreateMovementAsync(
                            stockLot: stockLot,
                            quantity: itemCommand.Quantity,
                            direction:
                                MovementDirectionEnum.Entry,
                            reason:
                                MovementReasonEnum.Adjustment,
                            movementDate:
                                command.AdjustmentDate,
                            sourceDocumentId:
                                adjustment.Id,
                            sourceDocumentType:
                                nameof(StockAdjustment),
                            responsibleId:
                                command.ResponsibleId,
                            movementCost:
                                itemCommand.Quantity *
                                itemCommand.UnitValue.Value,
                            cancellationToken:
                                cancellationToken);

                    adjustment.AddItem(
                        new StockAdjustmentItem(
                            productId:
                                itemCommand.ProductId,
                            quantity:
                                itemCommand.Quantity,
                            batch:
                                itemCommand.Batch,
                            brand:
                                itemCommand.Brand,
                            expiryDate:
                                itemCommand.ExpiryDate,
                            unitValue:
                                itemCommand.UnitValue));
                }
                else
                {
                    stock.DecreaseStock(itemCommand.Quantity);

                    var stockLot =
                        await _inventoryLotService.RemoveFromLotAsync(
                                stock: stock,
                                batch: itemCommand.Batch,
                                brand: itemCommand.Brand,
                                quantity: itemCommand.Quantity,
                                cancellationToken: cancellationToken);

                    var averageCost = stock.StockCost?.AverageUnitCost ?? 0;

                    _inventoryCostService.ProcessOutputCost(
                        stock,
                        itemCommand.Quantity);

                    await _inventoryMovementService
                        .CreateMovementAsync(
                            stockLot: stockLot,
                            quantity: itemCommand.Quantity,
                            direction:
                                MovementDirectionEnum.Output,
                            reason:
                                MovementReasonEnum.Adjustment,
                            movementDate:
                                command.AdjustmentDate,
                            sourceDocumentId:
                                adjustment.Id,
                            sourceDocumentType:
                                nameof(StockAdjustment),
                            responsibleId:
                                command.ResponsibleId,
                            movementCost:
                                averageCost *
                                itemCommand.Quantity,
                            cancellationToken:
                                cancellationToken);

                    adjustment.AddItem(
                        new StockAdjustmentItem(
                            productId:
                                itemCommand.ProductId,
                            quantity:
                                itemCommand.Quantity * -1,
                            batch:
                                stockLot.Batch,
                            brand:
                                stockLot.Brand,
                            expiryDate:
                                stockLot.ExpiryDate,
                            unitValue:
                                averageCost));
                }
            }

            await _dbContext.StockAdjustments
                .AddAsync(
                    adjustment,
                    cancellationToken);

            await _dbContext.SaveChangesAsync(
                cancellationToken);

            return Result<int>.Success(
                adjustment.Id,
                "Ajuste estoque realizado com sucesso.");
        }
    }
}
