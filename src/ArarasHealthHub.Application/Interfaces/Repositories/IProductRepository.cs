using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Product.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
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
