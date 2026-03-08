using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Commands.DeactivatePackagingType;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Validation
{
    public class DeactivatePackagingTypeCommandValidator : AbstractValidator<DeactivatePackagingTypeCommand>
    {
        public DeactivatePackagingTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
