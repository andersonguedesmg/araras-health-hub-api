using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Responses
{
    public sealed record LoginAccountResponse(
        int Id,
        string UserName,
        bool IsActive,
        int FacilityId,
        AccountScopeEnum Scope,
        AccountRoleEnum Role,
        string Token
    );
}
