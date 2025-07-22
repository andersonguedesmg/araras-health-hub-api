using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Commands.ChangeStatusSupplier;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class ChangeStatusSupplierCommandValidator : AbstractValidator<ChangeStatusSupplierCommand>
    {
        public ChangeStatusSupplierCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID do fornecedor é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
