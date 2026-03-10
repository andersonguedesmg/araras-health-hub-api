using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.DeactivateAccount
{
    public class DeactivateAccountCommandHandler : IRequestHandler<DeactivateAccountCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeactivateAccountCommandHandler(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> Handle(
            DeactivateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.Id.ToString());

            if (account is null)
                throw new NotFoundException("Conta não encontrada.");

            if (!account.IsActive)
                throw new BusinessRuleException("A conta já está inativa.");

            account.Deactivate();

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
                throw new BusinessRuleException("Erro ao desativar a conta.");

            return Result.Success("Conta desativada com sucesso.");
        }
    }
}
