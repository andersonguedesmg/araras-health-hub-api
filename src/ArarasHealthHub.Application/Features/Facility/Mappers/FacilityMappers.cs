using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Application.Features.Facility.Dtos;

namespace ArarasHealthHub.Application.Features.Facility.Mappers
{
    public static class FacilityMappers
    {
        public static FacilityDto ToFacilityDto(this FacilityDto facilityModel)
        {
            return new FacilityDto
            {
                Id = facilityModel.Id,
                Name = facilityModel.Name,
                Address = facilityModel.Address,
                Number = facilityModel.Number,
                Neighborhood = facilityModel.Neighborhood,
                City = facilityModel.City,
                State = facilityModel.State,
                Cep = facilityModel.Cep,
                Email = facilityModel.Email,
                Phone = facilityModel.Phone,
                CreatedOn = facilityModel.CreatedOn,
                UpdatedOn = facilityModel.UpdatedOn,
                IsActive = facilityModel.IsActive,
                // AccountUsers = facilityModel.AccountUsers.Select(d => d.ToAccountDto()).ToList(),
            };
        }

        public static FacilityDto ToFacilityFromCreateDto(this CreateFacilityRequestDto facilityModelDto)
        {
            return new FacilityDto
            {
                Name = facilityModelDto.Name,
                Address = facilityModelDto.Address,
                Number = facilityModelDto.Number,
                Neighborhood = facilityModelDto.Neighborhood,
                City = facilityModelDto.City,
                State = facilityModelDto.State,
                Cep = facilityModelDto.Cep,
                Email = facilityModelDto.Email,
                Phone = facilityModelDto.Phone,
                CreatedOn = facilityModelDto.CreatedOn,
                UpdatedOn = facilityModelDto.UpdatedOn,
                IsActive = facilityModelDto.IsActive,
            };
        }
    }
}
