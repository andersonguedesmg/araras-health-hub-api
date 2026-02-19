using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class GetAllSubCategoriesQueryValidator : PagedQueryValidator<GetAllSubCategoriesQuery>
    {
        public GetAllSubCategoriesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                        x.ToLower() is "name" or "maincategory" or "isactive")
                .WithMessage(ValidationMessages.InvalidOrderBy);
        }
    }
}
