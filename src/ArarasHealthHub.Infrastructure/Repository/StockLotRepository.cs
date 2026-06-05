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

        public async Task<Dictionary<int, List<StockLot>>> GetAvailableLotsByProductsFEFOAsync(
            IEnumerable<int> productIds,
            CancellationToken cancellationToken)
        {
            var ids = productIds
                .Distinct()
                .ToList();

            var lots = await _context.StockLots
                .AsNoTracking()
                .Include(x => x.Stock)
                .Where(x =>
                    ids.Contains(x.Stock.ProductId) &&
                    x.AvailableQuantity > 0)
                .OrderBy(x => x.ExpiryDate)
                .ThenBy(x => x.Id)
                .ToListAsync(cancellationToken);

            return lots
                .GroupBy(x => x.Stock.ProductId)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList());
        }
    }
}
