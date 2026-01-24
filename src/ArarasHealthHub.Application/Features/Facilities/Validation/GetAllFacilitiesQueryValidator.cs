using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities;
using ArarasHealthHub.Shared.Core.Pagination;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class GetAllFacilitiesQueryValidator : PagedQueryValidator<GetAllFacilitiesQuery>
    {
        public GetAllFacilitiesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.ToLower() is "name" or "cnes")
                .WithMessage("O campo de ordenação informado não é válido.");
        }
    }
}
