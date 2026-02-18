using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace araras_health_hub_api.Interfaces
{
    public interface IAccountManagementTarget
    {
        AccountScopeEnum Scope { get; }
        AccountRoleEnum Role { get; }
    }
}
