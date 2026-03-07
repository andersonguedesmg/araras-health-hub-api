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
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SupplierRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier?> GetByCnpjAsync(string cnpj, CancellationToken cancellationToken)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.Cnpj == cnpj, cancellationToken);
        }

        public async Task<bool> ExistsByCnpjAsync(string cnpj, int? ignoreId, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(s =>
                s.Cnpj == cnpj &&
                (!ignoreId.HasValue || s.Id != ignoreId.Value),
                cancellationToken);
        }
    }
}
