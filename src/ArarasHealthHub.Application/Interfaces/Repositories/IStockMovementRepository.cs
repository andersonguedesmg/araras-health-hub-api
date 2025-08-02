using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IStockMovementRepository : IBaseRepository<StockMovement>
    {
        Task<IEnumerable<StockMovement>> GetAllAsync(int pageNumber, int pageSize, string orderBy, string sortOrder);
        Task<int> GetTotalCountAsync();
        Task AddRangeAsync(IEnumerable<StockMovement> entities);
    }
}
