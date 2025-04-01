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
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock?> GetByProductIdAsync(int productId)
        {
            return await _context.Stock.Include(p => p.Product).FirstOrDefaultAsync(s => s.ProductId == productId);

        }

        public async Task UpdateStock(int productId, int quantity)
        {
            var stock = await _context.Stock.FirstOrDefaultAsync(s => s.ProductId == productId);

            if (stock == null)
            {
                await _context.Stock.AddAsync(new Stock { ProductId = productId, Quantity = quantity });
            }
            else
            {
                stock.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }
    }
}
