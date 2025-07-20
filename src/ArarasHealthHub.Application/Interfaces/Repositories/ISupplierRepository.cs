using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Supplier.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task<Supplier> CreateAsync(Supplier supplierModel);
        Task<Supplier?> UpdateAsync(int id, UpdateSupplierRequestDto supplierDto);
        Task<Supplier?> ChangeStatusAsync(int id, ChangeStatusSupplierRequestDto supplierDto);
        Task<Supplier?> DeleteAsync(int id);
    }
}
