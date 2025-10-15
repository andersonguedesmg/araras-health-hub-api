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
    public class ResourceManagementAuthorizationHandler : AuthorizationHandler<ResourceManagementRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResourceManagementAuthorizationHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceManagementRequirement requirement)
        {
            if (context.User.Identity?.IsAuthenticated != true)
            {
                context.Fail();
                return;
            }

            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                context.Fail();
                return;
            }

            var subjectUser = await _userManager.FindByIdAsync(userId);
            if (subjectUser == null)
            {
                context.Fail();
                return;
            }

            var subjectRoles = await _userManager.GetRolesAsync(subjectUser);

            if (subjectUser.Scope == UserScopeEnum.Management &&
                (subjectRoles.Contains("Master") || subjectRoles.Contains("Admin")))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
