using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.ChangeAccountPassword;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class ChangeAccountPasswordCommandValidator : AbstractValidator<ChangeAccountPasswordCommand>
    {
        public ChangeAccountPasswordCommandValidator()
        {
            RuleFor(x => x.TargetUserId)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");

            RuleFor(x => x.NewPassword)
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
        }
    }
}
