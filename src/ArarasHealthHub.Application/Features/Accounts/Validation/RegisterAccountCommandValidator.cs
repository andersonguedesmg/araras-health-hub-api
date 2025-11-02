using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Enums;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        private readonly IFacilityRepository _facilityRepo;

        public RegisterAccountCommandValidator(IFacilityRepository facilityRepo)
        {
            _facilityRepo = facilityRepo;

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
                .Length(3, 150).WithMessage("O nome de usuário deve ter entre 3 e 150 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(8).WithMessage("A senha deve ter no mínimo 8 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?~`]").WithMessage("A senha deve conter pelo menos um caractere especial.");

            RuleFor(x => x.FacilityId)
                .GreaterThan(0).WithMessage("O ID da unidade é obrigatório e deve ser um número válido.")
                .MustAsync(FacilityMustExist).WithMessage("A unidade informada não existe.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("A função é obrigatória.")
                .Must(BeAValidRole).WithMessage("Função inválida ou não permitida.");

            RuleFor(x => x)
                .Must(command => !(command.Role.ToUpper() == "MASTER" && command.Scope != UserScopeEnum.Management))
                .WithMessage("A função 'MASTER' é exclusiva para o escopo de Gerenciamento (Management).");

            RuleFor(x => x)
               .Must(command => !(command.Scope == UserScopeEnum.Operational && command.Role.ToUpper() == "MASTER"))
               .WithMessage("O escopo Operacional não pode ter a função 'MASTER'.");
        }

        private bool BeAValidRole(string role)
        {
            var allowedRoles = new List<string> { "MASTER", "ADMIN", "USER" };
            return allowedRoles.Contains(role.ToUpper());
        }

        private async Task<bool> FacilityMustExist(int facilityId, CancellationToken cancellationToken)
        {
            return await _facilityRepo.FacilityExists(facilityId);
        }
    }
}
