using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetAllPackagingTypes;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Validation
{
    public class GetAllPackagingTypesQueryValidator : PagedQueryValidator<GetAllPackagingTypesQuery>
    {
        public GetAllPackagingTypesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.Equals("name", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
