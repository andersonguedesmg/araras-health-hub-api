using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Supplier.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {

        private readonly ApplicationDBContext _context;

        public SupplierRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Supplier?> ChangeStatusAsync(int id, ChangeStatusSupplierRequestDto supplierDto)
        {
            var existingSupplier = await _context.Supplier.FirstOrDefaultAsync(u => u.Id == id);

            if (existingSupplier == null)
            {
                return null;
            }

            existingSupplier.IsActive = supplierDto.IsActive;
            existingSupplier.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingSupplier;
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
            existingSupplier.Cnpj = supplierDto.Cnpj;
            existingSupplier.Address = supplierDto.Address;
            existingSupplier.Number = supplierDto.Number;
            existingSupplier.Neighborhood = supplierDto.Neighborhood;
            existingSupplier.City = supplierDto.City;
            existingSupplier.State = supplierDto.State;
            existingSupplier.Cep = supplierDto.Cep;
            existingSupplier.Email = supplierDto.Email;
            existingSupplier.Phone = supplierDto.Phone;
            existingSupplier.UpdatedOn = DateTime.Now;
            existingSupplier.IsActive = supplierDto.IsActive;

            await _context.SaveChangesAsync();

            return existingSupplier;
        }
    }
}
