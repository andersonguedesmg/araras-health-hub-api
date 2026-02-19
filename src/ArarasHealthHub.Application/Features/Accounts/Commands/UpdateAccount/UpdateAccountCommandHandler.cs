using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, ApiResponse<object>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateAccountCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<object>> Handle(
            UpdateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (account is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Account)
                );
            }

            if (account.UserName == request.UserName)
            {
                return ApiResponse<object>.SuccessResponse(
                    StatusCodes.Status200OK,
                    ApiMessages.UpdatedSuccessfully(EntityNames.Account)
                );
            }

            var existingAccount = await _userManager.FindByNameAsync(request.UserName);

            if (existingAccount is not null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status400BadRequest,
                    ApiMessages.AccountNameAlreadyInUse
                );
            }

            account.UserName = request.UserName;

            var updateResult = await _userManager.UpdateAsync(account);

            if (!updateResult.Succeeded)
            {
                var errors = updateResult.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(
                        g => g.Key,
                        g => (IReadOnlyList<string>)g.Select(e => e.Description).ToList()
                    );

                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status500InternalServerError,
                    ApiMessages.FailedToUpdateAccount,
                    errors);
            }

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityUpdated(EntityNames.Account)
            );
        }
    }
}
