using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task<Stock?> GetByProductIdAsync(int productId);
        Task<IEnumerable<Stock>> GetStockOverviewAsync(int pageNumber, int pageSize, string orderBy, string sortOrder);
        Task<IEnumerable<Stock>> GetLowStockAsync();
        Task<int> GetTotalCountAsync();
    }
}
