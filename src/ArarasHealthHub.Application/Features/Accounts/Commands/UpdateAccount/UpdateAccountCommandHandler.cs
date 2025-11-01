using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateAccountCommandHandler(UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), false);
            }

            var targetRoles = await _userManager.GetRolesAsync(user);
            var targetRole = targetRoles.FirstOrDefault() ?? "User";
            var targetScope = user.Scope;

            var requiredPermission = new ManageAccountRequirement(targetScope, targetRole);

            var currentUser = _httpContextAccessor.HttpContext?.User;
            if (currentUser == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status401Unauthorized, ApiMessages.UnauthenticatedUser, false);
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(
                currentUser,
                null,
                requiredPermission
            );

            if (!authorizationResult.Succeeded)
            {
                return new ApiResponse<bool>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, false);
            }

            if (user.UserName != request.UserName)
            {
                if (await _userManager.FindByNameAsync(request.UserName) != null)
                {
                    return new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.AccountNameAlreadyInUse, false);
                }
            }

            user.UserName = request.UserName;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                var identityErrors = updateResult.Errors.Select(e => e.Description).ToList();
                var errorsDict = new Dictionary<string, List<string>> { { "GeneralErrors", identityErrors } };
                return new ApiResponse<bool>(StatusCodes.Status500InternalServerError, ApiMessages.FailedToUpdateAccount, errorsDict, false);
            }

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.UpdatedSuccessfully("Conta"), true);
        }
    }
}
