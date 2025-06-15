using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<Order?> GetByIdAsync(int id);
        Task<List<Order>> GetAllAsync();
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);
        Task UpdateAsync(Order order);
        Task UpdateOrderItemAsync(OrderItem orderItem);
    }
}
