using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.DestinationUser;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IDestinationUserRepository
    {
        Task<List<DestinationUser>> GetAllAsync();
        Task<DestinationUser?> GetByIdAsync(int id);
        Task<DestinationUser> CreateAsync(DestinationUser destinationUserModel);
        Task<DestinationUser?> UpdateAsync(int id, DestinationUser destinationUserModel);
        Task<DestinationUser?> DeleteAsync(int id);
    }
}
