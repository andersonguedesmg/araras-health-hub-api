using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.Include(s => s.Product).ToListAsync();
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
