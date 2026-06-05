using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order?> GetForApprovalAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task<Order?> GetForSeparationAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task<Order?> GetForFinalizationAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task<Order?> GetForCancellationAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task<Order?> GetForReturnAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task<Order?> GetDetailsAsync(
            int orderId,
            CancellationToken cancellationToken);

        Task<Order?> GetByIdForPickingAsync(
            int id,
            CancellationToken cancellationToken);
    }
}
