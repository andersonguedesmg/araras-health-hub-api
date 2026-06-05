using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Movements;
using ArarasHealthHub.Application.Interfaces.Services.Orders.Shared;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Services.Orders.Shared
{
    public class OrderStockService : IOrderStockService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IInventoryMovementService _movementService;

        public OrderStockService(
            IApplicationDbContext dbContext,
            IInventoryMovementService movementService)
        {
            _dbContext = dbContext;
            _movementService = movementService;
        }

        public async Task<List<StockLotAllocation>> AllocateFefoAsync(
            int productId,
            decimal quantity,
            CancellationToken cancellationToken)
        {
            var lots = await _dbContext.StockLots
                .Include(x => x.Stock)
                .Where(x =>
                    x.Stock.ProductId == productId &&
                    x.AvailableQuantity > 0 &&
                    x.ExpiryDate >= DateTime.UtcNow)
                .OrderBy(x => x.ExpiryDate)
                .ThenBy(x => x.CreatedOn)
                .ToListAsync(cancellationToken);

            var result = new List<StockLotAllocation>();

            var remaining = quantity;

            foreach (var lot in lots)
            {
                if (remaining <= 0)
                    break;

                var allocated = Math.Min(
                    remaining,
                    lot.AvailableQuantity);

                result.Add(
                    new StockLotAllocation(
                        lot,
                        allocated));

                remaining -= allocated;
            }

            if (remaining > 0)
            {
                throw new DomainRuleException(
                    $"Saldo insuficiente para o produto {productId}.");
            }

            return result;
        }

        public async Task ProcessStockExitAsync(
            List<StockLotAllocation> allocations,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType,
            CancellationToken cancellationToken)
        {
            foreach (var allocation in allocations)
            {
                allocation.StockLot.DecreaseQuantity(
                    allocation.Quantity);

                allocation.StockLot.Stock.DecreaseStock(
                    allocation.Quantity);

                await _movementService.CreateMovementAsync(
                    stockLot: allocation.StockLot,
                    quantity: allocation.Quantity,
                    direction: MovementDirectionEnum.Output,
                    reason: MovementReasonEnum.Dispensing,
                    movementDate: DateTime.UtcNow,
                    sourceDocumentId: sourceDocumentId,
                    sourceDocumentType: sourceDocumentType,
                    responsibleId: responsibleId,
                    movementCost: allocation.Quantity * allocation.StockLot.UnitValue,
                    cancellationToken: cancellationToken);
            }
        }

        public async Task ReleaseReservationAsync(
            int productId,
            decimal quantity,
            CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(
                    x => x.ProductId == productId,
                    cancellationToken);

            if (stock is null)
                throw new DomainException($"Estoque do produto {productId} não encontrado.");

            stock.ReleaseReservation(quantity);
        }

        public async Task ReserveApprovedItemsAsync(
            Order order,
            CancellationToken cancellationToken)
        {
            foreach (var item in order.OrderItems)
            {
                if (item.ApprovedQuantity <= 0)
                    continue;

                var stock = await _dbContext.Stocks
                    .FirstOrDefaultAsync(
                        x => x.ProductId == item.ProductId,
                        cancellationToken);

                if (stock is null)
                {
                    throw new DomainException(
                        $"Estoque do produto {item.ProductId} não encontrado.");
                }

                var available =
                    stock.CurrentQuantity -
                    stock.ReservedQuantity;

                if (item.ApprovedQuantity > available)
                {
                    throw new DomainRuleException(
                        $"Saldo insuficiente para o produto {item.ProductId}.");
                }

                stock.ReserveQuantity(
                    item.ApprovedQuantity);

                item.ReserveQuantity(
                    item.ApprovedQuantity);
            }
        }

        public async Task ReleaseReservedItemsAsync(
            Order order,
            CancellationToken cancellationToken)
        {
            foreach (var item in order.OrderItems)
            {
                if (item.ReservedQuantity <= 0)
                    continue;

                var stock = await _dbContext.Stocks
                    .FirstOrDefaultAsync(
                        x => x.ProductId == item.ProductId,
                        cancellationToken);

                if (stock is null)
                {
                    throw new DomainException(
                        $"Estoque do produto {item.ProductId} não encontrado.");
                }

                stock.ReleaseReservation(
                    item.ReservedQuantity);

                item.ReleaseReservation(
                    item.ReservedQuantity);
            }
        }

        public async Task<StockLot> ProcessStockReturnAsync(
            int stockLotId,
            decimal quantity,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType,
            CancellationToken cancellationToken)
        {
            if (quantity <= 0)
            {
                throw new DomainRuleException("Quantidade devolvida deve ser maior que zero.");
            }

            var stockLot =
                await _dbContext.StockLots
                    .Include(x => x.Stock)
                    .FirstOrDefaultAsync(
                        x => x.Id == stockLotId,
                        cancellationToken);

            if (stockLot is null)
            {
                throw new DomainException($"Lote {stockLotId} não encontrado.");
            }

            stockLot.IncreaseQuantity(quantity);

            stockLot.Stock.IncreaseStock(quantity);

            await _movementService.CreateMovementAsync(
                stockLot: stockLot,
                quantity: quantity,
                direction: MovementDirectionEnum.Entry,
                reason: MovementReasonEnum.Return,
                movementDate: DateTime.UtcNow,
                sourceDocumentId: sourceDocumentId,
                sourceDocumentType: sourceDocumentType,
                responsibleId: responsibleId,
                movementCost: quantity * stockLot.UnitValue,
                cancellationToken: cancellationToken);

            return stockLot;
        }
    }
}
