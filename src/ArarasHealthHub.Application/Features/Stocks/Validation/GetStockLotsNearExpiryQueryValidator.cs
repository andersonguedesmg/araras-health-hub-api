using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockLotsNearExpiry;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class GetStockLotsNearExpiryQueryValidator : PagedQueryValidator<GetStockLotsNearExpiryQuery>
    {
        public GetStockLotsNearExpiryQueryValidator()
        {
            RuleFor(x => x.ExpiryDaysThreshold)
                .GreaterThan(0)
                .WithMessage(
                    "Quantidade de dias deve ser maior que zero.");

            RuleFor(x => x.OrderBy)
                .Must(x =>
                    x == null ||
                    x.Equals("expirydate",
                        StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("productname",
                        StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
