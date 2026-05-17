using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class GetAllStockAdjustmentsQueryValidator : PagedQueryValidator<GetAllStockAdjustmentsQuery>
    {
        public GetAllStockAdjustmentsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x =>
                    x is null ||
                    x.Equals("type", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("reason", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("adjustmentdate", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("responsible", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
