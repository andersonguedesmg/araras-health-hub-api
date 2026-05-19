using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStocks;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class GetCriticalStocksQueryValidator : PagedQueryValidator<GetCriticalStocksQuery>
    {
        public GetCriticalStocksQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x =>
                    x is null ||
                    x.Equals("productname", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
