using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Commands.ActivateFacility;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class ActivateFacilityCommandValidator : AbstractValidator<ActivateFacilityCommand>
    {
        public ActivateFacilityCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
