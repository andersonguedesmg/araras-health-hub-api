using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class GetAllMainCategoriesQueryValidator : PagedRequestValidator<GetAllMainCategoriesQuery>
    {
        public GetAllMainCategoriesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.Equals("name", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
