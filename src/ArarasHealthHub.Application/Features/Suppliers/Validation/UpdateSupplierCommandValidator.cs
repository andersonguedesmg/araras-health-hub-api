using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;

        public UpdateSupplierCommandValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID do fornecedor é inválido.");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome do fornecedor é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do fornecedor não pode exceder 100 caracteres.");

            RuleFor(command => command.Cnpj)
                .NotEmpty().WithMessage("O CNPJ do fornecedor é obrigatório.")
                .Length(18).WithMessage("O CNPJ do fornecedor deve conter 18 dígitos.")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$").WithMessage("O CNPJ do fornecedor deve estar no formato 'XX.XXX.XXX/XXXX-XX'.")
                .MustAsync(BeUniqueCnpjForUpdate).WithMessage("Já existe outro fornecedor cadastrado com este CNPJ.");

            RuleFor(command => command.Address)
                .NotEmpty().WithMessage("O endereço do fornecedor é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço do fornecedor não pode exceder 200 caracteres.");

            RuleFor(command => command.Number)
                .NotEmpty().WithMessage("O número do endereço do fornecedor é obrigatório.")
                .MaximumLength(20).WithMessage("O número do endereço do fornecedor não pode exceder 20 caracteres.");

            RuleFor(command => command.Neighborhood)
                .NotEmpty().WithMessage("O bairro do fornecedor é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro do fornecedor não pode exceder 100 caracteres.");

            RuleFor(command => command.City)
                .NotEmpty().WithMessage("A cidade do fornecedor é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade do fornecedor não pode exceder 100 caracteres.");

            RuleFor(command => command.State)
                .NotEmpty().WithMessage("O estado do fornecedor é obrigatório.")
                .Length(2).WithMessage("O estado do fornecedor deve conter 2 caracteres (UF).")
                .Matches(@"^[A-Z]{2}$").WithMessage("O estado do fornecedor deve conter 2 letras maiúsculas (UF).");

            RuleFor(command => command.Cep)
                .NotEmpty().WithMessage("O CEP do fornecedor é obrigatório.")
                .Length(9).WithMessage("O CEP do fornecedor deve conter 9 dígitos.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP do fornecedor deve estar no formato 'XXXXX-XXX'.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("O email do fornecedor é obrigatório.")
                .EmailAddress().WithMessage("O formato do email do fornecedor é inválido.")
                .MaximumLength(100).WithMessage("O email do fornecedor não pode exceder 100 caracteres.");

            RuleFor(command => command.Phone)
                .NotEmpty().WithMessage("O telefone do fornecedor é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone do fornecedor não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$").WithMessage("O formato do telefone do fornecedor é inválido.");
        }

        private async Task<bool> BeUniqueCnpjForUpdate(UpdateSupplierCommand command, string cnpj, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByCnpjAsync(cnpj);
            return existingSupplier == null || existingSupplier.Id == command.Id;
        }
    }
}
