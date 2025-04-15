using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Facility;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IFacilityRepository
    {
        Task<List<Facility>> GetAllAsync();
        Task<Facility?> GetByIdAsync(int id);
        Task<Facility> CreateAsync(Facility facilityModel);
        Task<Facility?> UpdateAsync(int id, UpdateFacilityRequestDto facilityDto);
        Task<Facility?> ChangeStatusAsync(int id, ChangeStatusFacilityRequestDto facilityDto);
        Task<Facility?> DeleteAsync(int id);
        Task<bool> FacilityExists(int id);
    }
}
