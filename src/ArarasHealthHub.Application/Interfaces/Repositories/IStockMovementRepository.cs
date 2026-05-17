using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IStockMovementRepository : IBaseRepository<StockMovement>
    {
        Task AddRangeAsync(IEnumerable<StockMovement> entities);
        void AddRangeWithoutSaving(IEnumerable<StockMovement> entities);
    }
}
