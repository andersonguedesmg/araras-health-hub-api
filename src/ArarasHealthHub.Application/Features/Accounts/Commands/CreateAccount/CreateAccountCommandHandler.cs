using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<AccountCreatedResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFacilityRepository _facilityRepository;

        public CreateAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            IFacilityRepository facilityRepository)
        {
            _userManager = userManager;
            _facilityRepository = facilityRepository;
        }

        public async Task<Result<AccountCreatedResponse>> Handle(
            CreateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser is not null)
                throw new BusinessRuleException("Nome de usuário já está em uso.");

            var facility = await _facilityRepository
                .GetByIdAsync(request.FacilityId, cancellationToken);

            if (facility is null)
                throw new NotFoundException("Unidade não encontrada.");

            if (!facility.IsActive)
                throw new BusinessRuleException("Não é possível criar conta em unidade inativa.");

            var user = new ApplicationUser(
                request.UserName,
                request.UserName,
                request.FacilityId,
                request.Scope,
                request.Role
            );

            if (!request.IsActive)
                user.Deactivate();

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new BusinessRuleException("Erro ao criar conta.");

            var response = new AccountCreatedResponse(
                user.Id,
                user.UserName!,
                user.Role,
                user.Scope,
                user.FacilityId,
                user.IsActive
            );

            return Result<AccountCreatedResponse>.Success(response, "Conta criada com sucesso.");
        }
    }
}
