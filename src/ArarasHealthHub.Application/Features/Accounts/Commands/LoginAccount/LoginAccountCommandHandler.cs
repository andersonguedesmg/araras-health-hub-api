using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, ApiResponse<LoginAccountResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public LoginAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<LoginAccountResponse>> Handle(
            LoginAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByNameAsync(request.UserName);

            if (account is null)
            {
                return ApiResponse<LoginAccountResponse>.FailureResponse(
                    StatusCodes.Status401Unauthorized,
                    ApiMessages.AccountIncorrect);
            }

            if (!account.IsActive)
            {
                return ApiResponse<LoginAccountResponse>.FailureResponse(
                    StatusCodes.Status403Forbidden,
                    ApiMessages.AccountDisabled);
            }

            var passwordValid = await _userManager.CheckPasswordAsync(account, request.Password);

            if (!passwordValid)
            {
                return ApiResponse<LoginAccountResponse>.FailureResponse(
                    StatusCodes.Status401Unauthorized,
                    ApiMessages.AccountIncorrect);
            }

            var token = _tokenService.CreateToken(account);

            var response = new LoginAccountResponse(
                account.Id,
                account.UserName!,
                account.IsActive,
                account.FacilityId,
                account.Scope,
                account.Role,
                token);

            return ApiResponse<LoginAccountResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.AccountLoginSuccessful,
                response);
        }
    }
}
