using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Enums;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace araras_health_hub_api.Filters
{
    public class AuthorizeAccountManagementAttribute : TypeFilterAttribute
    {
        public AuthorizeAccountManagementAttribute(Type targetDtoType)
            : base(typeof(AccountManagementFilter))
        {
            Arguments = new object[] { targetDtoType };
        }
    }

    public class AccountManagementFilter : IAsyncActionFilter
    {
        private readonly Type _targetDtoType;
        private readonly IAuthorizationService _authorizationService;

        public AccountManagementFilter(Type targetDtoType, IAuthorizationService authorizationService)
        {
            _targetDtoType = targetDtoType;
            _authorizationService = authorizationService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var targetDto = context.ActionArguments.Values.FirstOrDefault(v => v?.GetType() == _targetDtoType);

            if (targetDto == null)
            {
                await next();
                return;
            }

            var targetScopeProp = _targetDtoType.GetProperty("Scope");
            var targetRoleProp = _targetDtoType.GetProperty("Role");

            if (targetScopeProp == null || targetRoleProp == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            var targetScopeEnum = (AccountScopeEnum)(targetScopeProp.GetValue(targetDto) ?? AccountScopeEnum.Unassigned);
            var targetRole = (string)(targetRoleProp.GetValue(targetDto) ?? string.Empty);

            var requirement = new ManageAccountRequirement(targetScopeEnum, targetRole);

            var authorizationResult = await _authorizationService.AuthorizeAsync(
                context.HttpContext.User,
                null,
                requirement);

            if (authorizationResult.Succeeded)
            {
                await next();
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
