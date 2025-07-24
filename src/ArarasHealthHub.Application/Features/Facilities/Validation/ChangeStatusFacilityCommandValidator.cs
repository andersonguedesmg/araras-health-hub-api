using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Commands.ChangeStatusFacility;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class ChangeStatusFacilityCommandValidator : AbstractValidator<ChangeStatusFacilityCommand>
    {
        public ChangeStatusFacilityCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID da unidade é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
