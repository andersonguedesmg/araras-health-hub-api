using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Commands.DeactivateFacility;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class DeactivateFacilityCommandValidator : AbstractValidator<DeactivateFacilityCommand>
    {
        public DeactivateFacilityCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
