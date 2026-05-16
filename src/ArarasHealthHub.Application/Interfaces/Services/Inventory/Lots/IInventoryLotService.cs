using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Services.Inventory.Lots
{
    public interface IInventoryLotService
    {
        Task<StockLot> GetOrCreateLotAsync(
            Stock stock,
            string batch,
            string brand,
            decimal unitValue,
            DateTime expiryDate,
            decimal quantity,
            int? receivedItemId,
            CancellationToken cancellationToken);
    }
}
