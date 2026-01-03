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
    public class PresentationFormRepository : BaseRepository<PresentationForm>, IPresentationFormRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PresentationFormRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PresentationForm?> GetByPresentationFormNameAsync(string name)
        {
            return await _dbContext.PresentationForms.AsNoTracking().FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }

        public IQueryable<PresentationForm> GetQueryable()
        {
            return _dbContext.Set<PresentationForm>();
        }
    }
}
