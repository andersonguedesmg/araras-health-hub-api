using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order orderModel)
        {
            await _context.Order.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Order
                .Include(o => o.OrderStatus)
                .Include(o => o.CreatedByEmployee)
                // .Include(o => o.CreatedByAccount)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Order
                .Include(o => o.OrderStatus)
                .Include(o => o.CreatedByEmployee)
                // .Include(o => o.CreatedByAccount)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItem.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItem.Update(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
