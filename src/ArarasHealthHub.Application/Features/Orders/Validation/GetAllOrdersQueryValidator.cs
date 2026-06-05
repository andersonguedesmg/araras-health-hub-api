using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class GetAllOrdersQueryValidator : PagedQueryValidator<GetAllOrdersQuery>
    {
        public GetAllOrdersQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.Equals("facility", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("status", StringComparison.OrdinalIgnoreCase) ||
                    x.Equals("createdon", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
