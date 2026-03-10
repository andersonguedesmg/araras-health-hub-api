using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Responses
{
    public sealed record AccountResponse(
        int Id,
        string UserName,
        bool IsActive,
        AccountScopeEnum Scope,
        AccountRoleEnum Role,
        DateTime CreatedOn,
        DateTime? UpdatedOn,
        FacilityResponse Facility
    );
}
