using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task UpdateStock(int productId, int quantity, string batch);
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByProductIdAsync(int productId);
    }
}
