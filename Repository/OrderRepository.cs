using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
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
                .Include(o => o.CreatedByAccount)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Order
                .Include(o => o.OrderStatus)
                .Include(o => o.CreatedByEmployee)
                .Include(o => o.CreatedByAccount)
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
    }
}
