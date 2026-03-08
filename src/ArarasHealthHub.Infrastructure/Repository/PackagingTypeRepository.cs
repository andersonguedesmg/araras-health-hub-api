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
    public class PackagingTypeRepository : BaseRepository<PackagingType>, IPackagingTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PackagingTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PackagingType?> GetByPackagingTypeNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.PackagingTypes.AsNoTracking().FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower(), cancellationToken);
        }

    }
}
