using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class DeactivateSupplierCommandValidator : AbstractValidator<DeactivateSupplierCommand>
    {
        public DeactivateSupplierCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
