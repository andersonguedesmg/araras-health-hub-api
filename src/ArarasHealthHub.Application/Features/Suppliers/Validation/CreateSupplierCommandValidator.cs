using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierCommandValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            RuleFor(x => x.LegalName)
                .NotEmpty()
                    .WithName("Razão Social")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(200));

            RuleFor(x => x.TradeName)
                .NotEmpty()
                    .WithName("Nome Fantasia")
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(200));

            RuleFor(x => x.Cnpj)
                .NotEmpty()
                    .WithName("CNPJ")
                    .WithMessage(ValidationMessages.RequiredField)
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$")
                    .WithMessage(ValidationMessages.InvalidCnpjFormat)
                .MustAsync(BeUniqueCnpj)
                    .WithMessage(ApiMessages.CnpjAlreadyExists);

            RuleFor(x => x.Address)
                .NotNull()
                    .WithName("endereço")
                    .WithMessage(ValidationMessages.RequiredObject)
                .SetValidator(new AddressDtoValidator());

            RuleFor(x => x.Contact)
                .NotNull()
                    .WithName("contato")
                    .WithMessage(ValidationMessages.RequiredObject)
                .SetValidator(new ContactDtoValidator());
        }

        private async Task<bool> BeUniqueCnpj(string cnpj, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByCnpjAsync(cnpj, cancellationToken);
            return existingSupplier == null;
        }
    }
}
