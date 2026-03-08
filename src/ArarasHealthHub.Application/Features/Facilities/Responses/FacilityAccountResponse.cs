using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Facilities.Responses
{
    public record FacilityAccountResponse(
        int Id,
        string UserName,
        bool IsActive,
        AccountScopeEnum Scope,
        AccountRoleEnum Role,
        DateTime CreatedOn,
        DateTime? UpdatedOn
    );
}
