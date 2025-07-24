using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ChangeStatusAccount
{
    public class ChangeStatusAccountCommandHandler : IRequestHandler<ChangeStatusAccountCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangeStatusAccountCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, false);
            }

            if (user.IsActive == request.IsActive)
            {
                return new ApiResponse<bool>(StatusCodes.Status200OK, $"O status da conta já esta {(request.IsActive ? "ativada" : "desativada")}.", true);
            }

            user.IsActive = request.IsActive;
            user.UpdatedOn = DateTime.UtcNow;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                var identityErrors = updateResult.Errors.Select(e => e.Description).ToList();
                return new ApiResponse<bool>(StatusCodes.Status500InternalServerError, ApiMessages.MsgFailedToChangeAccountStatus, identityErrors, false);
            }

            string successMessage = request.IsActive ? ApiMessages.MsgAccountActivatedSuccessfully : ApiMessages.MsgAccountDisabledSuccessfully;
            return new ApiResponse<bool>(StatusCodes.Status200OK, successMessage, true);
        }
    }
}
