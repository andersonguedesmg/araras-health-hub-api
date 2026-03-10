using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, Result<LoginAccountResponse>>
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

        public async Task<Result<LoginAccountResponse>> Handle(
            LoginAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByNameAsync(request.UserName);

            if (account is null)
                throw new BusinessRuleException("Usuário ou senha inválidos.");

            if (!account.IsActive)
                throw new BusinessRuleException("Conta desativada.");

            var passwordValid = await _userManager
                .CheckPasswordAsync(account, request.Password);

            if (!passwordValid)
                throw new BusinessRuleException("Usuário ou senha inválidos.");

            var token = _tokenService.CreateToken(account);

            var response = new LoginAccountResponse(
                account.Id,
                account.UserName!,
                account.IsActive,
                account.FacilityId,
                account.Scope,
                account.Role,
                token
            );

            return Result<LoginAccountResponse>.Success(response, "Login realizado com sucesso.");
        }
    }
}
