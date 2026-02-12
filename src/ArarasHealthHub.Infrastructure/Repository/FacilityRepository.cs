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
    public class FacilityRepository : BaseRepository<Facility>, IFacilityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FacilityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> FacilityExists(int id, CancellationToken cancellationToken)
        {
            return _dbSet.AnyAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Facility?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.Name == name, cancellationToken);
        }

        public async Task<Facility?> GetByIdWithAccountsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet
                .Include(f => f.Accounts)
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        }
    }
}
