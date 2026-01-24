using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class GetSupplierByIdQueryValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        public GetSupplierByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador do fornecedor é inválido.");
        }
    }
}
