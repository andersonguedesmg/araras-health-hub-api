using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.User;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Function = userModel.Function,
                Phone = userModel.Phone,
                CreatedOn = userModel.CreatedOn,
                UpdatedOn = userModel.UpdatedOn,
                IsActive = userModel.IsActive,
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto userModelDto)
        {
            return new User
            {
                Name = userModelDto.Name,
                Function = userModelDto.Function,
                Phone = userModelDto.Phone,
                CreatedOn = userModelDto.CreatedOn,
                IsActive = userModelDto.IsActive,
            };
        }
    }
}
