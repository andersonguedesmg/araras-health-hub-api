using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateAccountCommandHandler(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> Handle(
            UpdateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager
                .FindByIdAsync(request.UserId.ToString());

            if (account is null)
                throw new NotFoundException("Conta não encontrada.");

            if (account.UserName == request.UserName)
                return Result.Success("Conta atualizada com sucesso.");

            var existing = await _userManager
                .FindByNameAsync(request.UserName);

            if (existing is not null)
                throw new BusinessRuleException("Nome de usuário já está em uso.");

            account.UserName = request.UserName;

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
                throw new BusinessRuleException("Erro ao atualizar conta.");

            return Result.Success("Conta atualizada com sucesso.");
        }
    }
}
