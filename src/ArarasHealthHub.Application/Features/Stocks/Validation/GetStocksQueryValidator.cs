using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Queries.GetStocks;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class GetStocksQueryValidator : PagedQueryValidator<GetStocksQuery>
    {
        public GetStocksQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x =>
                    x == null ||
                    x.Equals("productname",
                        StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("availablequantity",
                        StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("minquantity",
                        StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
