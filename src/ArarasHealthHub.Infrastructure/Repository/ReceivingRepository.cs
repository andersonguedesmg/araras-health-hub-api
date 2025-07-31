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
    public class ReceivingRepository : BaseRepository<Receiving>, IReceivingRepository
    {
        public ReceivingRepository(ApplicationDbContext context) : base(context) { }


        public async Task<Receiving?> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.ReceivingItems)
                    .ThenInclude(ri => ri.Product)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Receiving>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.ReceivingItems)
                    .ThenInclude(ri => ri.Product)
                .ToListAsync();
        }
    }
}
