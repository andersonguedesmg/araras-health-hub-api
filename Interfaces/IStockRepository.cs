using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IStockRepository
    {
        Task UpdateStock(int productId, int quantity, string batch);
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByProductIdAsync(int productId);
    }
}
