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
    public class MainCategoryRepository : BaseRepository<MainCategory>, IMainCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MainCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MainCategory?> GetByMainCategoryNameAsync(string name)
        {
            return await _dbContext.MainCategories.AsNoTracking().FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower());
        }

        public IQueryable<MainCategory> GetQueryable()
        {
            return _dbContext.Set<MainCategory>();
        }
    }
}
