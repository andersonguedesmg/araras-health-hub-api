using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public StockRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Stock?> GetByProductIdAsync(int productId)
        {
            return await _dbContext.Stocks
                .Include(s => s.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ProductId == productId);
        }

        public async Task<IEnumerable<Stock>> GetStockOverviewAsync(int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            var query = _dbContext.Stocks
                .Include(s => s.Product)
                .AsNoTracking();

            switch (orderBy.ToLower())
            {
                case "productname":
                    query = sortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(s => s.Product.Name) :
                        query.OrderBy(s => s.Product.Name);
                    break;
                case "currentquantity":
                    query = sortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(s => s.CurrentQuantity) :
                        query.OrderBy(s => s.CurrentQuantity);
                    break;
                default:
                    query = sortOrder.ToLower() == "desc" ?
                        query.OrderByDescending(s => s.Id) :
                        query.OrderBy(s => s.Id);
                    break;
            }

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Stock>> GetLowStockAsync()
        {
            return await _dbContext.Stocks
                .Include(s => s.Product)
                .AsNoTracking()
                .Where(s => s.CurrentQuantity <= s.MinQuantity)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _dbContext.Stocks.CountAsync();
        }
    }
}
