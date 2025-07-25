using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IFacilityRepository : IBaseRepository<Facility>
    {
        Task<bool> FacilityExists(int id);

        Task<Facility?> GetByNameAsync(string name);

        Task<Facility?> GetByIdWithAccountsAsync(int id);
    }
}
