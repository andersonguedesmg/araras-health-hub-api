using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class StockMovementRepository : BaseRepository<StockMovement>, IStockMovementRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public StockMovementRepository(IApplicationDbContext dbContext) : base((ApplicationDbContext)dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StockMovement>> GetAllAsync(int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            var query = _dbContext.StockMovements
                .Include(sm => sm.Product)
                .Include(sm => sm.Responsible)
                .AsNoTracking();

            switch (orderBy.ToLower())
            {
                case "productname":
                    query = sortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(sm => sm.Product.Name) :
                        query.OrderBy(sm => sm.Product.Name);
                    break;
                case "createdon":
                    query = sortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(sm => sm.CreatedOn) :
                        query.OrderBy(sm => sm.CreatedOn);
                    break;
                default:
                    query = sortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(sm => sm.Id) :
                        query.OrderBy(sm => sm.Id);
                    break;
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _dbContext.StockMovements.CountAsync();
        }

        public async Task AddRangeAsync(IEnumerable<StockMovement> entities)
        {
            await _dbContext.Set<StockMovement>().AddRangeAsync(entities);
        }
    }
}
