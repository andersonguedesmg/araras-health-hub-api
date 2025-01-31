using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.DestinationUser;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Mappers
{
    public static class DestinationUserMappers
    {
        public static DestinationUserDto ToDestinationUserDto(this DestinationUser DestinationModel)
        {
            return new DestinationUserDto
            {
                Id = DestinationModel.Id,
                Name = DestinationModel.Name,
                Password = DestinationModel.Password,
                Role = DestinationModel.Role,
                CreatedOn = DestinationModel.CreatedOn,
                UpdatedOn = DestinationModel.UpdatedOn,
                IsActive = DestinationModel.IsActive,
                DestinationId = DestinationModel.DestinationId,
            };
        }

        public static DestinationUser ToDestinationUserFromCreateDto(this CreateDestinationUserRequestDto DestinationUserModelDto, int destinationId)
        {
            return new DestinationUser
            {
                Name = DestinationUserModelDto.Name,
                Password = DestinationUserModelDto.Password,
                Role = DestinationUserModelDto.Role,
                CreatedOn = DestinationUserModelDto.CreatedOn,
                UpdatedOn = DestinationUserModelDto.UpdatedOn,
                IsActive = DestinationUserModelDto.IsActive,
                DestinationId = destinationId,
            };
        }

        public static DestinationUser ToDestinationUserFromUpdate(this UpdateDestinationUserRequestDto destinationUserDto)
        {
            return new DestinationUser
            {
                Name = destinationUserDto.Name,
                Password = destinationUserDto.Password,
                Role = destinationUserDto.Role,
                UpdatedOn = destinationUserDto.UpdatedOn,
                IsActive = destinationUserDto.IsActive,
            };
        }
    }
}
