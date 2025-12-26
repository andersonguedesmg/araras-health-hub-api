using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IStockRepository : IBaseRepository<Stock>
    {
        Task<Stock?> GetByProductIdAsync(int productId);
        Task<IEnumerable<Stock>> GetLowStockAsync();
        Task<int> GetTotalCountAsync();
        IQueryable<Stock> GetQueryable();
        IQueryable<Stock> GetLowStockQueryable();
    }
}
