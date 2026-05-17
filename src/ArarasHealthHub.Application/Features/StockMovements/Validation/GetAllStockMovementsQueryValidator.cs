using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.StockMovements.Validation
{
    public class GetAllStockMovementsQueryValidator : PagedQueryValidator<GetAllStockMovementsQuery>
    {
        public GetAllStockMovementsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("productname", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("direction", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("reason", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("movementdate", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("responsible", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
