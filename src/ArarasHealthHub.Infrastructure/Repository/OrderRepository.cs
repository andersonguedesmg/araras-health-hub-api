using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Order?> GetForApprovalAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(
                    x => x.Id == orderId,
                    cancellationToken);
        }

        public async Task<Order?> GetForSeparationAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)

                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.OrderItemLots)
                        .ThenInclude(x => x.StockLot)

                .AsSplitQuery()

                .FirstOrDefaultAsync(
                    x => x.Id == orderId,
                    cancellationToken);
        }

        public async Task<Order?> GetForFinalizationAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.OrderItemLots)
                        .ThenInclude(x => x.StockLot)

                .AsSplitQuery()

                .FirstOrDefaultAsync(
                    x => x.Id == orderId,
                    cancellationToken);
        }

        public async Task<Order?> GetForCancellationAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)

                .FirstOrDefaultAsync(
                    x => x.Id == orderId,
                    cancellationToken);
        }

        public async Task<Order?> GetForReturnAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.OrderItemLots)
                        .ThenInclude(x => x.StockLot)

                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)

                .FirstOrDefaultAsync(
                    x => x.Id == orderId,
                    cancellationToken);
        }

        public async Task<Order?> GetDetailsAsync(
            int orderId,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(x => x.OrderStatus)
                .Include(x => x.OrderFacility)

                .Include(x => x.CreatedByEmployee)
                .Include(x => x.CreatedByAccount)

                .Include(x => x.ApprovedByEmployee)
                .Include(x => x.ApprovedByAccount)

                .Include(x => x.SeparatedByEmployee)
                .Include(x => x.SeparatedByAccount)

                .Include(x => x.FinalizedByEmployee)
                .Include(x => x.FinalizedByAccount)

                .Include(x => x.CanceledByEmployee)
                .Include(x => x.CanceledByAccount)

                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)

                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.OrderItemLots)
                        .ThenInclude(x => x.StockLot)

                .AsSplitQuery()

                .FirstOrDefaultAsync(
                    x => x.Id == orderId,
                    cancellationToken);
        }

        public async Task<Order?> GetByIdForPickingAsync(
            int id,
            CancellationToken cancellationToken)
        {
            return await _context.Orders
                .AsNoTracking()
                .Include(x => x.OrderStatus)
                .Include(x => x.OrderFacility)
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken);
        }
    }
}
