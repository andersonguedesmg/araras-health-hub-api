using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Responses
{
    public sealed record AccountCreatedResponse(
        int UserId,
        string UserName,
        AccountRoleEnum Role,
        AccountScopeEnum Scope,
        int FacilityId,
        bool IsActive
    );
}
