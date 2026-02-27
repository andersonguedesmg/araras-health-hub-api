using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Commands.DeactivateMainCategory;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class DeactivateMainCategoryCommandValidator : AbstractValidator<DeactivateMainCategoryCommand>
    {
        public DeactivateMainCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
