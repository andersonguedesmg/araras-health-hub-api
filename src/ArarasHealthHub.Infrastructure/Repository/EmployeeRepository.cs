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
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee?> GetByCpfAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Cpf == cpf);
        }

        public async Task<bool> EmployeeExists(int id)
        {
            return await _dbSet.AnyAsync(s => s.Id == id);
        }

        public IQueryable<Employee> GetQueryable()
        {
            return _dbContext.Set<Employee>();
        }
    }
}
