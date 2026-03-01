using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Commands.ActivateSupplier;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class ActivateSupplierCommandValidator : AbstractValidator<ActivateSupplierCommand>
    {
        public ActivateSupplierCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
