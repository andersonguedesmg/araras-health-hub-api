using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateAccountCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), false);
            }

            if (user.UserName != request.UserName)
            {
                if (await _userManager.FindByNameAsync(request.UserName) != null)
                {
                    return new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.AccountNameAlreadyInUse, false);
                }
            }

            user.UserName = request.UserName;
            user.UpdatedOn = DateTime.UtcNow;

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
