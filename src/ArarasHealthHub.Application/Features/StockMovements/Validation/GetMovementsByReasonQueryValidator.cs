using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByReason;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.StockMovements.Validation
{
    public class GetMovementsByReasonQueryValidator : PagedQueryValidator<GetMovementsByReasonQuery>
    {
        public GetMovementsByReasonQueryValidator()
        {
            RuleFor(x => x.Reason)
                .IsInEnum();
        }
    }
}
