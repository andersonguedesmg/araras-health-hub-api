using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Product;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product?> ChangeStatusAsync(int id, ChangeStatusProductRequestDto productDto)
        {
            var existingProduct = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.IsActive = productDto.IsActive;
            existingProduct.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Product.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Product.FirstOrDefaultAsync(u => u.Id == id);

            if (productModel == null)
            {
                return null;
            }

            _context.Product.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto)
        {
            var existingProduct = await _context.Product.FirstOrDefaultAsync(d => d.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Manufacturer = productDto.Manufacturer;
            existingProduct.Format = productDto.Format;
            existingProduct.Category = productDto.Category;
            existingProduct.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingProduct;
        }
    }
}
