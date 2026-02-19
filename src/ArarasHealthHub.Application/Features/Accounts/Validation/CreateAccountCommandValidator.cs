using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.CreateAccount;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        private readonly IFacilityRepository _facilityRepository;

        public CreateAccountCommandValidator(
            IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;

            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithName("Usuário")
                    .WithMessage(ValidationMessages.RequiredField)
                .MinimumLength(3)
                    .WithMessage(ValidationMessages.MinLengthField(3))
                .MaximumLength(150)
                    .WithMessage(ValidationMessages.MaxLengthField(150));

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithName("Senha")
                    .WithMessage(ValidationMessages.RequiredField)
                .MinimumLength(8)
                    .WithMessage(ValidationMessages.MinLengthField(8))
                .Matches("[A-Z]")
                    .WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]")
                    .WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]")
                    .WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?~`]")
                    .WithMessage("A senha deve conter pelo menos um caractere especial.");

            RuleFor(x => x.FacilityId)
                .GreaterThan(0)
                    .WithName("Unidade")
                    .WithMessage(ValidationMessages.RequiredField)
                .MustAsync(FacilityMustExist)
                    .WithMessage("A unidade informada não existe.");

            RuleFor(x => x.Scope)
                .IsInEnum()
                    .WithName("Escopo")
                    .WithMessage("Escopo inválido.");

            RuleFor(x => x.Role)
                .IsInEnum()
                    .WithName("Função")
                    .WithMessage("Função inválida.");

            RuleFor(x => x)
                .Must(BeValidScopeRoleCombination)
                .WithMessage("A função MASTER é exclusiva do escopo Management.");
        }

        private async Task<bool> FacilityMustExist(
            int facilityId,
            CancellationToken cancellationToken)
        {
            return await _facilityRepository
                .FacilityExists(facilityId, cancellationToken);
        }

        private static bool BeValidScopeRoleCombination(
            CreateAccountCommand command)
        {
            if (command.Role == AccountRoleEnum.Master &&
                command.Scope != AccountScopeEnum.Management)
            {
                return false;
            }

            return true;
        }
    }
}
