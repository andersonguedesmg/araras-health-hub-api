using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class GetAllMinimumStockLevelsQueryValidator : PagedQueryValidator<GetAllStockMovementsQuery>
    {
        public GetAllMinimumStockLevelsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("productname", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("minimumstocklevel", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("currentquantity", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
