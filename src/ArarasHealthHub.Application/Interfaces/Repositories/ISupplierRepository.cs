using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task CreateAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Supplier supplier);
        Task<Supplier?> GetByCnpjAsync(string cnpj);
    }
}
