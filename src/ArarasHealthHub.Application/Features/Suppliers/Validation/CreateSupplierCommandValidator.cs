using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve conter 14 dígitos.")
                .Matches(@"^\d{14}$").WithMessage("O CNPJ deve conter apenas números.")
                .MustAsync(BeUniqueCnpj).WithMessage("Já existe um fornecedor cadastrado com este CNPJ.");

            RuleFor(command => command.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço não pode exceder 200 caracteres.");

            RuleFor(command => command.Number)
                .NotEmpty().WithMessage("O número do endereço é obrigatório.")
                .MaximumLength(20).WithMessage("O número do endereço não pode exceder 20 caracteres.");

            RuleFor(command => command.Neighborhood)
                .NotEmpty().WithMessage("O bairro é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro não pode exceder 100 caracteres.");

            RuleFor(command => command.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade não pode exceder 100 caracteres.");

            RuleFor(command => command.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve conter 2 caracteres (UF).")
                .Matches(@"^[A-Z]{2}$").WithMessage("O estado deve conter 2 letras maiúsculas (UF).");

            RuleFor(command => command.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Length(8).WithMessage("O CEP deve conter 8 dígitos.")
                .Matches(@"^\d{8}$").WithMessage("O CEP deve conter apenas números.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O formato do email é inválido.")
                .MaximumLength(100).WithMessage("O email não pode exceder 100 caracteres.");

            RuleFor(command => command.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$").WithMessage("O formato do telefone é inválido.");
        }

        private async Task<bool> BeUniqueCnpj(string cnpj, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByCnpjAsync(cnpj);
            return existingSupplier == null;
        }
    }
}
