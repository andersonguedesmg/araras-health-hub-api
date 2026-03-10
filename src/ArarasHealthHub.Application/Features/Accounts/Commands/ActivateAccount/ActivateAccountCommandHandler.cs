using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ActivateAccount
{
    public class ActivateAccountCommandHandler : IRequestHandler<ActivateAccountCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFacilityRepository _facilityRepository;

        public ActivateAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            IFacilityRepository facilityRepository)
        {
            _userManager = userManager;
            _facilityRepository = facilityRepository;
        }

        public async Task<Result> Handle(
            ActivateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.Id.ToString());

            if (account is null)
                throw new NotFoundException("Conta não encontrada.");

            if (account.IsActive)
                throw new BusinessRuleException("A conta já está ativa.");

            var facility = await _facilityRepository
                .GetByIdAsync(account.FacilityId, cancellationToken);

            if (facility is null || !facility.IsActive)
                throw new BusinessRuleException("Não é possível ativar a conta pois a unidade está inativa.");

            account.Activate();

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
                throw new BusinessRuleException("Erro ao ativar a conta.");

            return Result.Success("Conta ativada com sucesso.");
        }
    }
}
