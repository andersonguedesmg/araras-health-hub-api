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
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            var allStockEntries = await _context.Stock.Include(s => s.Product).ToListAsync();
            var filteredStock = new List<Stock>();
            var groupedByProduct = allStockEntries.GroupBy(s => s.ProductId);

            foreach (var group in groupedByProduct)
            {
                if (group.Count() == 1)
                {
                    var singleEntry = group.First();
                    filteredStock.Add(singleEntry);
                }
                else
                {
                    var validEntries = group.Where(s => s.Quantity > 0 || !string.IsNullOrEmpty(s.Batch)).ToList();
                    filteredStock.AddRange(validEntries);
                }
            }

            return filteredStock;
        }

        public async Task<Stock?> GetByProductIdAsync(int productId)
        {
            return await _context.Stock.Include(p => p.Product).FirstOrDefaultAsync(s => s.ProductId == productId);

        }

        public async Task UpdateStock(int productId, int quantity, string batch)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(s => s.ProductId == productId && s.Batch == batch);

            if (stock == null)
            {
                await _context.Stock.AddAsync(new Stock
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Batch = batch
                });
            }
            else
            {
                stock.Quantity += quantity;
            }

            var emptyStock = await _context.Stock.FirstOrDefaultAsync(s => s.ProductId == productId && s.Batch == "" && s.Quantity == 0);

            if (emptyStock != null)
            {
                _context.Stock.Remove(emptyStock);
            }

            await _context.SaveChangesAsync();
        }
    }
}
