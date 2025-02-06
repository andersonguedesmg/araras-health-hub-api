using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Destination;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllAsync();
        Task<Destination?> GetByIdAsync(int id);
        Task<Destination> CreateAsync(Destination destinationModel);
        Task<Destination?> UpdateAsync(int id, UpdateDestinationRequestDto destinationDto);
        Task<Destination?> ChangeStatusAsync(int id, ChangeStatusDestinationRequestDto destinationDto);
        Task<Destination?> DeleteAsync(int id);
        Task<bool> DestinationExists(int id);
    }
}
