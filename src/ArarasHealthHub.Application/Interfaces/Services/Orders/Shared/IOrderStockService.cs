using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Shared
{
    public interface IOrderStockService
    {
        Task ReserveApprovedItemsAsync(
            Order order,
            CancellationToken cancellationToken);

        Task ReleaseReservedItemsAsync(
            Order order,
            CancellationToken cancellationToken);

        Task<List<StockLotAllocation>> AllocateFefoAsync(
            int productId,
            decimal quantity,
            CancellationToken cancellationToken);

        Task ProcessStockExitAsync(
            List<StockLotAllocation> allocations,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType,
            CancellationToken cancellationToken);

        Task ReleaseReservationAsync(
            int productId,
            decimal quantity,
            CancellationToken cancellationToken);

        Task<StockLot> ProcessStockReturnAsync(
            int stockLotId,
            decimal quantity,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType,
            CancellationToken cancellationToken);
    }
}
