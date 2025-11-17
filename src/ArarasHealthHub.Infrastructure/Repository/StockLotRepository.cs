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
    public class StockLotRepository : BaseRepository<StockLot>, IStockLotRepository
    {
        public StockLotRepository(ApplicationDbContext context) : base(context) { }

        public async Task<StockLot?> GetByStockIdAndBatchAndBrandAsync(int stockId, string batch, string brand)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(sl => sl.StockId == stockId && sl.Batch == batch && sl.Brand == brand);
        }
    }
}
