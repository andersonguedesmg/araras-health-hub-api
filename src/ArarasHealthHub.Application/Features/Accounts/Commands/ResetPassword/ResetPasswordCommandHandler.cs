using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, false);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (result.Succeeded)
            {
                return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.MsgPasswordResetSuccessfully, true);
            }
            else
            {
                var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                return new ApiResponse<bool>(StatusCodes.Status400BadRequest, $"Falha ao redefinir a senha: {errors}", false);
            }
        }
    }
}
