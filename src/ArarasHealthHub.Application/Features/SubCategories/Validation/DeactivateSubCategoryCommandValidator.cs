using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Commands.DeactivateSubCategory;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class DeactivateSubCategoryCommandValidator : AbstractValidator<DeactivateSubCategoryCommand>
    {
        public DeactivateSubCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
