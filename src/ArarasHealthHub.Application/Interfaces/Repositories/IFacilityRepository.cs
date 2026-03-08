using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IFacilityRepository : IBaseRepository<Facility>
    {
        Task<bool> FacilityExists(int id, CancellationToken cancellationToken);

        Task<Facility?> GetByNameAsync(string name, CancellationToken cancellationToken);

        Task<bool> ExistsByCnesAsync(string cnes, int? ignoreId, CancellationToken cancellationToken);

        Task<Facility?> GetByIdWithAccountsAsync(int id, CancellationToken cancellationToken);
    }
}
