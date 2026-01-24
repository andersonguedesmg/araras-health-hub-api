using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Shared.Core.Pagination;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class GetAllSuppliersQueryValidator : PagedQueryValidator<GetAllSuppliersQuery>
    {
        public GetAllSuppliersQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.ToLower() is "legalName" or "tradeName" or "cnpj")
                .WithMessage("O campo de ordenação informado não é válido.");
        }
    }
}
