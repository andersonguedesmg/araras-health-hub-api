using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class GetAllMainCategoriesQueryValidator : PagedQueryValidator<GetAllMainCategoriesQuery>
    {
        public GetAllMainCategoriesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                        x.ToLower() is "name")
                .WithMessage(ValidationMessages.InvalidOrderBy);
        }
    }
}
