using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Product;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(int id, UpdateProductRequestDto productDto);
        Task<Product?> ChangeStatusAsync(int id, ChangeStatusProductRequestDto productDto);
        Task<Product?> DeleteAsync(int id);
    }
}
