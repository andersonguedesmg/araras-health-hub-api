using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByPeriod;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.StockMovements.Validation
{
    public class GetStockMovementsByPeriodQueryValidator : PagedQueryValidator<GetStockMovementsByPeriodQuery>
    {
        public GetStockMovementsByPeriodQueryValidator()
        {
            RuleFor(x => x.StartDate)
                .NotEmpty();

            RuleFor(x => x.EndDate)
                .NotEmpty();

            RuleFor(x => x)
                .Must(x => x.EndDate >= x.StartDate)
                .WithMessage(
                    "Data final deve ser maior que data inicial.");
        }
    }
}
