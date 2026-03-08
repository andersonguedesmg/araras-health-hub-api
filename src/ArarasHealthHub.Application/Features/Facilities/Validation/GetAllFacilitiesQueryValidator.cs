using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class GetAllFacilitiesQueryValidator : PagedQueryValidator<GetAllFacilitiesQuery>
    {
        public GetAllFacilitiesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                        x.Equals("name", StringComparison.OrdinalIgnoreCase) ||
                        x.Equals("cnes", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
