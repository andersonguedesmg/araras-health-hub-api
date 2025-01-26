using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly ApplicationDBContext _context;

        public SupplierRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Supplier> CreateAsync(Supplier supplierModel)
        {
            await _context.Supplier.AddAsync(supplierModel);
            await _context.SaveChangesAsync();
            return supplierModel;
        }

        public async Task<Supplier?> DeleteAsync(int id)
        {
            var supplierModel = await _context.Supplier.FirstOrDefaultAsync(d => d.Id == id);

            if (supplierModel == null)
            {
                return null;
            }

            _context.Supplier.Remove(supplierModel);
            await _context.SaveChangesAsync();
            return supplierModel;
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Supplier.ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Supplier.FindAsync(id);
        }

        public async Task<Supplier?> UpdateAsync(int id, UpdateSupplierRequestDto supplierDto)
        {
            var existingSupplier = await _context.Supplier.FirstOrDefaultAsync(d => d.Id == id);

            if (existingSupplier == null)
            {
                return null;
            }

            existingSupplier.Name = supplierDto.Name;
            existingSupplier.Address = supplierDto.Address;
            existingSupplier.Number = supplierDto.Number;
            existingSupplier.Neighborhood = supplierDto.Neighborhood;
            existingSupplier.City = supplierDto.City;
            existingSupplier.State = supplierDto.State;
            existingSupplier.Cep = supplierDto.Cep;
            existingSupplier.Email = supplierDto.Email;
            existingSupplier.Phone = supplierDto.Phone;
            existingSupplier.UpdatedOn = supplierDto.UpdatedOn;
            existingSupplier.IsActive = supplierDto.IsActive;

            await _context.SaveChangesAsync();

            return existingSupplier;
        }
    }
}
