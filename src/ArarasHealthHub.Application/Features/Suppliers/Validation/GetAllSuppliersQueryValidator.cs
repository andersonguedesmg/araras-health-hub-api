using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class GetAllSuppliersQueryValidator : PagedQueryValidator<GetAllSuppliersQuery>
    {
        public GetAllSuppliersQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                        x.Equals("legalname", StringComparison.OrdinalIgnoreCase) ||
                        x.Equals("tradename", StringComparison.OrdinalIgnoreCase) ||
                        x.Equals("cnpj", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
