using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDBContext context) : base(context) { }

        public async Task<Supplier?> GetByCnpjAsync(string cnpj)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Cnpj == cnpj);
        }
    }
}
