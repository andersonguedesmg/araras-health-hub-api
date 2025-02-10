using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Account;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Mappers
{
    public static class AccountMappers
    {
        public static AccountDto ToAccountDto(this AppUser AppUserModel)
        {
            return new AccountDto
            {
                UserName = AppUserModel.UserName,
                CreatedOn = AppUserModel.CreatedOn,
                UpdatedOn = AppUserModel.UpdatedOn,
                IsActive = AppUserModel.IsActive,
                DestinationId = AppUserModel.DestinationId,
            };
        }
    }
}
