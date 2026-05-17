using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByProduct;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.StockMovements.Validation
{
    public class GetStockMovementsByProductQueryValidator : PagedQueryValidator<GetStockMovementsByProductQuery>
    {
        public GetStockMovementsByProductQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("movementdate", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("direction", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
