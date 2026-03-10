using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.CreateAccount;
using ArarasHealthHub.Domain.Enums;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Usuário é obrigatório.")
                .MinimumLength(3).WithMessage("Usuário deve ter pelo menos 3 caracteres.")
                .MaximumLength(256).WithMessage("Usuário não pode exceder 256 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(8).WithMessage("Senha deve ter pelo menos 8 caracteres.")
                .MaximumLength(256).WithMessage("Senha não pode exceder 256 caracteres.")
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
                .WithMessage("Identificador inválido.");

            RuleFor(x => x.Scope)
                .IsInEnum().WithMessage("Escopo inválido.");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Função inválida.");

            RuleFor(x => x)
                .Must(BeValidScopeRoleCombination)
                .WithMessage("A função MASTER é exclusiva do escopo Management.");
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
