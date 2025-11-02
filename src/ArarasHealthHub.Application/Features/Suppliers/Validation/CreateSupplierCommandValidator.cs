using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSupplierCommandValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome do fornecedor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do fornecedor não pode exceder 100 caracteres.");

            RuleFor(command => command.Cnpj)
                .NotEmpty().WithMessage("O CNPJ do fornecedor é obrigatório.")
                .Length(18).WithMessage("O CNPJ do fornecedor deve conter 18 dígitos.")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$").WithMessage("O CNPJ do fornecedor deve estar no formato 'XX.XXX.XXX/XXXX-XX'.")
                .MustAsync(BeUniqueCnpj).WithMessage("Já existe outro fornecedor cadastrado com este CNPJ.");

            RuleFor(command => command.Address)
                .NotNull().WithMessage("O objeto de endereço é obrigatório.")
                .SetValidator(new AddressDtoValidator());

            RuleFor(command => command.Contact)
                .NotNull().WithMessage("O objeto de contato é obrigatório.")
                .SetValidator(new ContactDtoValidator());
        }

        private async Task<bool> BeUniqueCnpj(string cnpj, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByCnpjAsync(cnpj);
            return existingSupplier == null;
        }
    }
}
