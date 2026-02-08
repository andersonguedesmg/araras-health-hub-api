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
    public class SubCategoryRepository : BaseRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SubCategory?> GetBySubCategoryNameAndMainCategoryIdAsync(string name, int mainCategoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.SubCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Name.ToLower() == name.ToLower() &&
                    x.MainCategoryId == mainCategoryId,
                    cancellationToken);
        }

        public IQueryable<SubCategory> AsQueryableWithMainCategory()
        {
            return _dbContext.SubCategories
                .Include(m => m.MainCategory)
                .AsNoTracking();
        }
    }
}
