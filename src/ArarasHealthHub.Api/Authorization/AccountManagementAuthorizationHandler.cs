using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Authorization;
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

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ManageAccountRequirement requirement)
        {
            if (context.User.Identity?.IsAuthenticated != true)
            {
                context.Fail();
                return;
            }

            var subjectUser = await _userManager.GetUserAsync(context.User);
            if (subjectUser == null || !subjectUser.IsActive)
            {
                context.Fail();
                return;
            }

            var subjectRole = subjectUser.Role;
            var subjectScope = subjectUser.Scope;

            var targetScope = requirement.TargetScope;
            var targetRole = requirement.TargetRole;

            if (subjectScope != targetScope)
            {
                context.Fail();
                return;
            }

            if (subjectRole <= targetRole)
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
        }
    }
}
