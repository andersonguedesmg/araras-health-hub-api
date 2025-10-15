using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

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

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (result.Succeeded)
            {
                return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.PasswordResetSuccessfully, true);
            }
            else
            {
                var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                return new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.PasswordResetFailed(errors), false);
            }
        }
    }
}
