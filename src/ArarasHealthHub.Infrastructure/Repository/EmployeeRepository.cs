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
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Employee?> GetByCpfAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Cpf == cpf);
        }

        public async Task<bool> EmployeeExists(int id)
        {
            return await _dbSet.AnyAsync(s => s.Id == id);
        }
    }
}
