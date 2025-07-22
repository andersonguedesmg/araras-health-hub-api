using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task CreateAsync(Supplier supplier)
        {
            await _context.Supplier.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Supplier supplier)
        {
            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _context.Supplier.ToListAsync();
        }

        public async Task<Supplier?> GetByCnpjAsync(string cnpj)
        {
            return await _context.Supplier.FirstOrDefaultAsync(s => s.Cnpj == cnpj);
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _context.Supplier.FindAsync(id);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Supplier.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
