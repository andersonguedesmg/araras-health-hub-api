using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.LegalName)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .MaximumLength(200).WithMessage("A razão social deve ter no máximo 200 caracteres.");

            RuleFor(x => x.TradeName)
                .MaximumLength(200).WithMessage("O nome fantasia deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
                .WithMessage("O CNPJ deve estar no formato 00.000.000/0000-00.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("O endereço é obrigatório.")
                .SetValidator(new AddressRequestValidator());

            RuleFor(x => x.Contact)
                .NotNull().WithMessage("O contato é obrigatório.")
                .SetValidator(new ContactRequestValidator());
        }
    }
}
