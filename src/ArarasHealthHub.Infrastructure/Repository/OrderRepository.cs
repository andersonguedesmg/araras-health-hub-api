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

        public async Task<Order?> GetByIdWithItemsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderFacility)
                .Include(o => o.CreatedByEmployee)
                .Include(o => o.CreatedByAccount)
                    .ThenInclude(a => a!.Facility)
                .Include(o => o.ApprovedByEmployeeId)
                .Include(o => o.ApprovedByAccountId)
                // .ThenInclude(a => a!.Facility)
                .Include(o => o.SeparatedByEmployeeId)
                .Include(o => o.SeparatedByAccountId)
                // .ThenInclude(a => a!.Facility)
                .Include(o => o.FinalizedByEmployeeId)
                .Include(o => o.FinalizedByAccountId)
                // .ThenInclude(a => a!.Facility)
                .Include(o => o.CanceledByEmployeeId)
                .Include(o => o.CanceledByAccountId)
                // .ThenInclude(a => a!.Facility)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            return orderItem;
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }

        public async Task<IEnumerable<Order>> GetAllWithItemsAsync(int? orderStatusId = null, int? facilityId = null)
        {
            IQueryable<Order> query = _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                        .ThenInclude(p => p!.Stock)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderFacility)
                .Include(o => o.CreatedByEmployee)
                .Include(o => o.CreatedByAccount)
                    .ThenInclude(a => a!.Facility)
                .Include(o => o.ApprovedByEmployeeId)
                .Include(o => o.ApprovedByAccountId)
                // .ThenInclude(a => a!.Facility)
                .Include(o => o.SeparatedByEmployeeId)
                .Include(o => o.SeparatedByAccountId)
                // .ThenInclude(a => a!.Facility)
                .Include(o => o.FinalizedByEmployeeId)
                .Include(o => o.FinalizedByAccountId)
                // .ThenInclude(a => a!.Facility)
                .Include(o => o.CanceledByEmployeeId)
                .Include(o => o.CanceledByAccountId)
                // .ThenInclude(a => a!.Facility)
                .AsSplitQuery()
                .AsQueryable();

            if (orderStatusId.HasValue)
            {
                query = query.Where(o => o.OrderStatusId == orderStatusId.Value);
            }

            if (facilityId.HasValue)
            {
                query = query.Where(o => o.OrderFacilityId == facilityId.Value);
            }

            return await query.ToListAsync();
        }

        public IQueryable<Order> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}
