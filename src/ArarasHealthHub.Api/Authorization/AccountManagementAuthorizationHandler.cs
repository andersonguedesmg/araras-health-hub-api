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
    public class AccountManagementAuthorizationHandler
        : AuthorizationHandler<ManageAccountRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountManagementAuthorizationHandler(
            UserManager<ApplicationUser> userManager)
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

            if (subjectUser is null || !subjectUser.IsActive)
            {
                context.Fail();
                return;
            }

            if (subjectUser.Scope != requirement.TargetScope)
            {
                context.Fail();
                return;
            }

            if (subjectUser.Role <= requirement.TargetRole)
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
        }
    }
}
