using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        public RegisterAccountCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
                .Length(3, 50).WithMessage("O nome de usuário deve ter entre 3 e 50 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?~`]").WithMessage("A senha deve conter pelo menos um caractere especial.");

            RuleFor(x => x.FacilityId)
                .GreaterThan(0).WithMessage("O ID da Facility é obrigatório e deve ser um número válido.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("A Role é obrigatória.")
                .Must(BeAValidRole).WithMessage("Role inválida ou não permitida.");
        }

        private bool BeAValidRole(string role)
        {
            var allowedRoles = new List<string> { "User", "Manager", "Admin" };
            return allowedRoles.Contains(role);
        }
    }
}
