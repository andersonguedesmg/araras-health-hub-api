using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ChangeAccountPassword
{
    public class ChangeAccountPasswordCommandHandler : IRequestHandler<ChangeAccountPasswordCommand, ApiResponse<object>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChangeAccountPasswordCommandHandler(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<object>> Handle(
            ChangeAccountPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var targetUser = await _userManager.FindByIdAsync(request.TargetUserId.ToString());

            if (targetUser is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Account)
                );
            }

            var currentUserPrincipal = _httpContextAccessor.HttpContext?.User;

            if (currentUserPrincipal is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status401Unauthorized,
                    ApiMessages.UnauthenticatedUser
                );
            }

            var currentRole = Enum.Parse<AccountRoleEnum>(
                currentUserPrincipal.FindFirst("role")!.Value);

            var currentFacilityId = int.Parse(
                currentUserPrincipal.FindFirst("facilityId")!.Value);

            if (currentRole == AccountRoleEnum.User)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status403Forbidden,
                    ApiMessages.InsufficientPermissions
                );
            }

            if (currentRole == AccountRoleEnum.Admin &&
                targetUser.FacilityId != currentFacilityId)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status403Forbidden,
                    ApiMessages.InsufficientPermissions
                );
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(targetUser);

            var result = await _userManager.ResetPasswordAsync(
                targetUser,
                token,
                request.NewPassword);

            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(
                        g => g.Key,
                        g => (IReadOnlyList<string>)g.Select(e => e.Description).ToList()
                    );

                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status400BadRequest,
                    ApiMessages.FailedToResetPassword,
                    errors
                );
            }

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.PasswordResetSuccessfully
            );
        }
    }
}
