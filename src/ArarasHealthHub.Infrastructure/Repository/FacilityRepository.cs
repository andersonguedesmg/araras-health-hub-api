using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class FacilityRepository : BaseRepository<Facility>, IFacilityRepository
    {
        public FacilityRepository(ApplicationDbContext context) : base(context) { }

        public Task<bool> FacilityExists(int id)
        {
            return _dbSet.AnyAsync(s => s.Id == id);
        }

        public async Task<Facility?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}
