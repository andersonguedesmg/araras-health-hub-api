using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class ReceivingRepository : IReceivingRepository
    {
        private readonly ApplicationDbContext _context;

        public ReceivingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Receiving> CreateAsync(Receiving receivingModel)
        {
            await _context.Receiving.AddAsync(receivingModel);
            await _context.SaveChangesAsync();
            return receivingModel;
        }

        public async Task<Receiving?> GetByIdAsync(int id)
        {
            return await _context.Receiving
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.ReceivedItems)
                .ThenInclude(ri => ri.Product)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Receiving>> GetAllAsync()
        {
            return await _context.Receiving
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.ReceivedItems)
                .ThenInclude(ri => ri.Product)
                .ToListAsync();
        }

        public async Task<ReceivingItem> CreateReceivingItemAsync(ReceivingItem receivingItem)
        {
            await _context.ReceivingItem.AddAsync(receivingItem);
            await _context.SaveChangesAsync();
            return receivingItem;
        }
    }
}
