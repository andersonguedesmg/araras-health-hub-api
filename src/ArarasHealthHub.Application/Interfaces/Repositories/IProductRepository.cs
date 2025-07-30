using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<bool> HasProductNameUnique(string name, int productId, CancellationToken cancellationToken);

        Task<Product?> GetByProductNameAsync(string name);

        Task<bool> ProductExists(int id);
    }
}
