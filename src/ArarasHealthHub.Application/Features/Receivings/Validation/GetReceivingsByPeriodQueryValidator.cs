using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingsByPeriod;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Receivings.Validation
{
    public class GetReceivingsByPeriodQueryValidator : PagedQueryValidator<GetReceivingsByPeriodQuery>
    {
        public GetReceivingsByPeriodQueryValidator()
        {
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate);

            RuleFor(x => x.EndDate)
                .LessThanOrEqualTo(DateTime.UtcNow);

            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("invoicenumber", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("receivingdate", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("totalvalue", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
