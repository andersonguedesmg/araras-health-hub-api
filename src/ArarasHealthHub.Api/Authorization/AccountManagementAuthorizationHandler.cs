using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace araras_health_hub_api.Authorization
{
    public class AccountManagementAuthorizationHandler : AuthorizationHandler<ManageAccountRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountManagementAuthorizationHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAccountRequirement requirement)
        {
            var subjectUser = await _userManager.GetUserAsync(context.User);
            if (subjectUser == null || context.User.Identity?.IsAuthenticated == false)
            {
                context.Fail();
                return;
            }

            var subjectRoles = await _userManager.GetRolesAsync(subjectUser);
            var subjectScope = subjectUser.Scope;

            var targetScope = requirement.TargetScope;
            var targetRole = requirement.TargetRole;

            if (subjectRoles.Contains("Master") && subjectScope == AccountScopeEnum.Management)
            {
                context.Succeed(requirement);
                return;
            }

            if (subjectScope == AccountScopeEnum.Management && (subjectRoles.Contains("Master") || subjectRoles.Contains("Admin")))
            {
                if (targetRole == "Admin" || targetRole == "User")
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            if (targetRole == "Master")
            {
                context.Fail();
                return;
            }

            context.Fail();
        }
    }
}
