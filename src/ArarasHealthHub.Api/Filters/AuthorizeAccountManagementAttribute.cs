using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Interfaces;

using ArarasHealthHub.Domain.Authorization;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace araras_health_hub_api.Filters
{
    public class AuthorizeAccountManagementAttribute : TypeFilterAttribute
    {
        public AuthorizeAccountManagementAttribute()
            : base(typeof(AccountManagementFilter))
        {
        }
    }

    public class AccountManagementFilter : IAsyncActionFilter
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountManagementFilter(
            IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var targetDto = context.ActionArguments
                .Values
                .OfType<IAccountManagementTarget>()
                .FirstOrDefault();

            if (targetDto == null)
            {
                await next();
                return;
            }

            var requirement = new ManageAccountRequirement(
                targetDto.Scope,
                targetDto.Role
            );

            var result = await _authorizationService.AuthorizeAsync(
                context.HttpContext.User,
                null,
                requirement
            );

            if (!result.Succeeded)
            {
                context.Result = new ForbidResult();
                return;
            }

            await next();
        }
    }
}
