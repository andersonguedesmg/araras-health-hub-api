using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

using Microsoft.AspNetCore.Authorization;

namespace ArarasHealthHub.Domain.Authorization
{
    public class ManageAccountRequirement : IAuthorizationRequirement
    {
        public AccountScopeEnum TargetScope { get; }
        public string TargetRole { get; }

        public ManageAccountRequirement(AccountScopeEnum targetScope, string targetRole)
        {
            TargetScope = targetScope;
            TargetRole = targetRole;
        }
    }
}
