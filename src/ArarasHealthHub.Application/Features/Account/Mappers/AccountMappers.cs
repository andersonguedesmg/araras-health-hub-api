using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Account.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Account.Mappers
{
    public static class AccountMappers
    {
        public static AccountDto ToAccountDto(this AccountDto accountModel)
        {
            return new AccountDto
            {
                UserName = accountModel.UserName,
                CreatedOn = accountModel.CreatedOn,
                UpdatedOn = accountModel.UpdatedOn,
                IsActive = accountModel.IsActive,
                FacilityId = accountModel.FacilityId,
            };
        }
    }
}
