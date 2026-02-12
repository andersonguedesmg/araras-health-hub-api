using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ChangeStatusAccount
{
    public class ChangeStatusAccountCommandHandler : IRequestHandler<ChangeStatusAccountCommand, ApiResponseO<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChangeStatusAccountCommandHandler(UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponseO<bool>> Handle(ChangeStatusAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                return new ApiResponseO<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), false);
            }

            var targetRoles = await _userManager.GetRolesAsync(user);
            var targetRole = targetRoles.FirstOrDefault() ?? "User";
            var targetScope = user.Scope;

            var requiredPermission = new ManageAccountRequirement(targetScope, targetRole);

            var currentUser = _httpContextAccessor.HttpContext?.User;
            if (currentUser == null || !currentUser.Identity!.IsAuthenticated)
            {
                return new ApiResponseO<bool>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, false);
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(
                currentUser,
                null,
                requiredPermission
            );

            if (!authorizationResult.Succeeded)
            {
                return new ApiResponseO<bool>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, false);
            }

            if (user.IsActive == request.IsActive)
            {
                var statusText = request.IsActive ? "ativada" : "desativada";
                return new ApiResponseO<bool>(StatusCodes.Status200OK, ApiMessages.AccountStatusAlreadyAsDesired(statusText), true);
            }

            user.IsActive = request.IsActive;
            user.UpdatedOn = DateTime.UtcNow;

            IdentityResult updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                if (request.IsActive)
                {
                    updateResult = await _userManager.SetLockoutEnabledAsync(user, false);
                    if (updateResult.Succeeded)
                    {
                        updateResult = await _userManager.SetLockoutEndDateAsync(user, null);
                    }
                }
                else
                {
                    updateResult = await _userManager.SetLockoutEnabledAsync(user, true);
                    if (updateResult.Succeeded)
                    {
                        updateResult = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                    }
                }
            }

            if (!updateResult.Succeeded)
            {
                var identityErrors = updateResult.Errors.Select(e => e.Description).ToList();
                var errorsDict = new Dictionary<string, List<string>> { { "GeneralErrors", identityErrors } };
                return new ApiResponseO<bool>(StatusCodes.Status500InternalServerError, ApiMessages.FailedToChangeAccountStatus, errorsDict, false);
            }

            string successMessage = request.IsActive ? ApiMessages.ActivatedSuccessfully("Conta") : ApiMessages.DeactivatedSuccessfully("Conta");
            return new ApiResponseO<bool>(StatusCodes.Status200OK, successMessage, true);
        }
    }
}
