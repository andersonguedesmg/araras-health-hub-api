using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace araras_health_hub_api.Authorization
{
    public class ResourceManagementAuthorizationHandler
        : AuthorizationHandler<ResourceManagementRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResourceManagementAuthorizationHandler(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ResourceManagementRequirement requirement)
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

            if (subjectUser.Scope != AccountScopeEnum.Management)
            {
                context.Fail();
                return;
            }

            if (subjectUser.Role is AccountRoleEnum.Master or AccountRoleEnum.Admin)
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
        }
    }
}
