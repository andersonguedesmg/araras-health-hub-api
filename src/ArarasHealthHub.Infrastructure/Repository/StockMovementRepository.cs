using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class StockMovementRepository : BaseRepository<StockMovement>, IStockMovementRepository
    {
        public StockMovementRepository(IApplicationDbContext dbContext) : base((ApplicationDbContext)dbContext)
        {
        }

        public async Task AddRangeAsync(
            IEnumerable<StockMovement> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void AddRangeWithoutSaving(
            IEnumerable<StockMovement> entities)
        {
            _dbSet.AddRange(entities);
        }
    }
}
