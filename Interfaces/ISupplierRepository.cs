using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
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
