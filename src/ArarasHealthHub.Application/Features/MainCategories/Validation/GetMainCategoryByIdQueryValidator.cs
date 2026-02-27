using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryById;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class GetMainCategoryByIdQueryValidator : AbstractValidator<GetMainCategoryByIdQuery>
    {
        public GetMainCategoryByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
