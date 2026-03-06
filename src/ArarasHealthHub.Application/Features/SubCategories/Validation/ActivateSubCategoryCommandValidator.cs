using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class ActivateSubCategoryCommandValidator : AbstractValidator<ActivateSubCategoryCommand>
    {
        public ActivateSubCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
