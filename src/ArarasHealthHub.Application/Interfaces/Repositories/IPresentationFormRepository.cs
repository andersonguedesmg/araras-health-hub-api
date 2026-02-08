using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IPresentationFormRepository : IBaseRepository<PresentationForm>
    {
        Task<PresentationForm?> GetByPresentationFormNameAsync(string name, CancellationToken cancellationToken);
    }
}
