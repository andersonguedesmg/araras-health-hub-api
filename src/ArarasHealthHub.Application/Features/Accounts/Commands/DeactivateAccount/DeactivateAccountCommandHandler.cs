using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.DeactivateAccount
{
    public class DeactivateAccountCommandHandler : IRequestHandler<DeactivateAccountCommand, ApiResponse<object>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeactivateAccountCommandHandler(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<object>> Handle(
            DeactivateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.Id.ToString());

            if (account is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Account));
            }

            if (!account.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyInactive(EntityNames.Account));
            }

            account.Deactivate();

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status500InternalServerError,
                    ApiMessages.FailedToChangeAccountStatus);
            }

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityDeactivated(EntityNames.Account));
        }
    }
}
