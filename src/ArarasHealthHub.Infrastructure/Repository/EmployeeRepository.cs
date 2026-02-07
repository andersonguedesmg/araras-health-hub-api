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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Employee?> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
        {
            return await _dbSet
                .FirstOrDefaultAsync(e => e.Cpf == cpf, cancellationToken);
        }

        public async Task<bool> EmployeeExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _dbSet
                .AnyAsync(e => e.Id == id, cancellationToken);
        }
    }
}
