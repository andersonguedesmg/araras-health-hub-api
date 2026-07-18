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
            return !await _dbContext.Products.AnyAsync(p => p.Name.ToLower() == name.ToLower() && p.Id != productId, cancellationToken);
        }

        public async Task<Product?> GetByProductNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower(), cancellationToken);
        }

        public async Task<bool> ProductExists(int id)
        {
            return await _dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByIdWithStockAsync(int id)
        {
            return await _dbContext.Products
                .Include(p => p.MainCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.PackagingTypeId)
                .Include(p => p.Stock)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetByIdWithIncludesAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .Include(p => p.MainCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.PackagingType)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public IQueryable<Product> AsQueryableWithIncludes()
        {
            return _dbContext.Products
                .Include(p => p.MainCategory)
                .Include(p => p.SubCategory)
                .Include(p => p.PackagingTypeId)
                .AsNoTracking();
        }
    }
}
