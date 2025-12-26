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
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Stock?> GetByProductIdAsync(int productId)
        {
            return await _dbContext.Stocks
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ProductId == productId);
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

        public IQueryable<Stock> GetQueryable()
        {
            return _dbContext.Stocks.AsNoTracking();
        }

        public IQueryable<Stock> GetLowStockQueryable()
        {
            return _dbContext.Stocks
                .Include(s => s.Product)
                .AsNoTracking()
                .Where(s => s.CurrentQuantity <= s.MinQuantity);
        }
    }
}
