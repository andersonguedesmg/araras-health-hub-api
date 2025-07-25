using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(command => command.UserName)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
                .NotNull().WithMessage("O nome de usuário não pode ser nulo.");

            RuleFor(command => command.NewPassword)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?~`]").WithMessage("A senha deve conter pelo menos um caractere especial.");
        }
    }
}
