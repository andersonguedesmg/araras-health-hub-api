using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Commands.ActivatePackagingType;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Validation
{
    public class ActivatePackagingTypeCommandValidator : AbstractValidator<ActivatePackagingTypeCommand>
    {
        public ActivatePackagingTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
