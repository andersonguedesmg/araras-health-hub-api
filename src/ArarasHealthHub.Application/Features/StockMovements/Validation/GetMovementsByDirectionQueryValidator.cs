using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByDirection;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.StockMovements.Validation
{
    public class GetMovementsByDirectionQueryValidator : PagedQueryValidator<GetMovementsByDirectionQuery>
    {
        public GetMovementsByDirectionQueryValidator()
        {
            RuleFor(x => x.Direction)
                .IsInEnum();
        }
    }
}
