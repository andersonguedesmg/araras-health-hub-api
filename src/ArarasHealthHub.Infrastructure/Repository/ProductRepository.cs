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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HasProductNameUnique(string name, int productId, CancellationToken cancellationToken)
        {
            return !await _dbContext.Products.AnyAsync(p => p.Name == name && p.Id != productId, cancellationToken);
        }

        public async Task<Product?> GetByProductNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task<bool> ProductExists(int id)
        {
            return await _dbSet.AnyAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByIdWithStockAsync(int id)
        {
            return await _dbContext.Products
                .Include(p => p.Stock)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
