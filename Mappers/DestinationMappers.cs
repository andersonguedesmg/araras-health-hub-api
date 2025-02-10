using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Destination;
using araras_health_hub_api.Dtos.Account;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Mappers
{
    public static class DestinationMappers
    {
        public static DestinationDto ToDestinationDto(this Destination DestinationModel)
        {
            return new DestinationDto
            {
                Id = DestinationModel.Id,
                Name = DestinationModel.Name,
                Address = DestinationModel.Address,
                Number = DestinationModel.Number,
                Neighborhood = DestinationModel.Neighborhood,
                City = DestinationModel.City,
                State = DestinationModel.State,
                Cep = DestinationModel.Cep,
                Email = DestinationModel.Email,
                Phone = DestinationModel.Phone,
                CreatedOn = DestinationModel.CreatedOn,
                UpdatedOn = DestinationModel.UpdatedOn,
                IsActive = DestinationModel.IsActive,
                AccountUsers = DestinationModel.AccountUsers.Select(d => d.ToAccountDto()).ToList(),
            };
        }

        public static Destination ToDestinationFromCreateDto(this CreateDestinationRequestDto DestinationModelDto)
        {
            return new Destination
            {
                Name = DestinationModelDto.Name,
                Address = DestinationModelDto.Address,
                Number = DestinationModelDto.Number,
                Neighborhood = DestinationModelDto.Neighborhood,
                City = DestinationModelDto.City,
                State = DestinationModelDto.State,
                Cep = DestinationModelDto.Cep,
                Email = DestinationModelDto.Email,
                Phone = DestinationModelDto.Phone,
                CreatedOn = DestinationModelDto.CreatedOn,
                UpdatedOn = DestinationModelDto.UpdatedOn,
                IsActive = DestinationModelDto.IsActive,
            };
        }
    }
}
