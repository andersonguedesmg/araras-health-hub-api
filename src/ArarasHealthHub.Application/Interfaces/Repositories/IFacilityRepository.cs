using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facility.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
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
