using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Receivings.Validation
{
    public class GetAllReceivingsQueryValidator : PagedQueryValidator<GetAllReceivingsQuery>
    {
        public GetAllReceivingsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("invoicenumber", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("receivingdate", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("supplierlegalname", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("suppliertradename", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("totalvalue", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
