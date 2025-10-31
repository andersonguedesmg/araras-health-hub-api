using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class StockCostRepository : BaseRepository<StockCost>, IStockCostRepository
    {
        public StockCostRepository(ApplicationDbContext context) : base(context) { }

        public async Task<StockCost?> GetByStockIdAsync(int stockId)
        {
            return await _context.StockCosts
                .AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.StockId == stockId);
        }
    }
}
