using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingsByProduct;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Receivings.Validation
{
    public class GetReceivingsByProductQueryValidator : PagedQueryValidator<GetReceivingsByProductQuery>
    {
        public GetReceivingsByProductQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("invoicenumber", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("receivingdate", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("totalvalue", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
