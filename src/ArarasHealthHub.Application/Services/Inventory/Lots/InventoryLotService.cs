using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Lots;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Services.Inventory.Lots
{
    public class InventoryLotService : IInventoryLotService
    {
        private readonly IApplicationDbContext _dbContext;

        public InventoryLotService(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StockLot> GetOrCreateLotAsync(
            Stock stock,
            string batch,
            string brand,
            decimal unitValue,
            DateTime expiryDate,
            decimal quantity,
            int? receivedItemId,
            CancellationToken cancellationToken)
        {
            var existingLot = stock.Lots.FirstOrDefault(x =>
                x.Batch == batch &&
                x.Brand == brand &&
                x.ExpiryDate.Date == expiryDate.Date &&
                x.UnitValue == unitValue);

            if (existingLot is not null)
            {
                existingLot.IncreaseQuantity(quantity);

                return existingLot;
            }

            var stockLot = new StockLot(
                stockId: stock.Id,
                batch: batch,
                brand: brand,
                unitValue: unitValue,
                expiryDate: expiryDate,
                quantity: quantity,
                receivedItemId: receivedItemId);

            await _dbContext.StockLots.AddAsync(
                stockLot,
                cancellationToken);

            return stockLot;
        }
    }
}
