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

        public async Task<Receiving?> GetByIdWithDetailsAsync(
            int id,
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(
                    r => r.Id == id,
                    cancellationToken);
        }

        public async Task<List<Receiving>> GetAllWithDetailsAsync(
            CancellationToken cancellationToken)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(r => r.Supplier)
                .Include(r => r.Responsible)
                .Include(r => r.Account)
                .Include(r => r.Items)
                    .ThenInclude(i => i.Product)
                .ToListAsync(cancellationToken);
        }
    }
}
