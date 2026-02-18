using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public sealed record AccountListItemResponse(
        int UserId,
        string UserName,
        bool IsActive,
        AccountScopeEnum Scope,
        AccountRoleEnum Role,
        DateTime CreatedOn,
        DateTime? UpdatedOn,
        FacilityResponse Facility
    );
}
