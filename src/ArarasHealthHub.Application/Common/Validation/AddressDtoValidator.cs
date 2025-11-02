using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using FluentValidation;

namespace ArarasHealthHub.Application.Common.Validation
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(address => address.Street)
                .NotEmpty().WithMessage("A rua do endereço é obrigatória.")
                .MaximumLength(200).WithMessage("A rua do endereço não pode exceder 200 caracteres.");

            RuleFor(address => address.Number)
                .NotEmpty().WithMessage("O número do endereço é obrigatório.")
                .MaximumLength(20).WithMessage("O número do endereço não pode exceder 20 caracteres.");

            RuleFor(address => address.Complement)
                .MaximumLength(100).WithMessage("O complemento não pode exceder 100 caracteres.");

            RuleFor(address => address.Neighborhood)
                .NotEmpty().WithMessage("O bairro é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro não pode exceder 100 caracteres.");

            RuleFor(address => address.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade não pode exceder 100 caracteres.");

            RuleFor(address => address.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve conter 2 caracteres (UF).")
                .Matches(@"^[A-Z]{2}$").WithMessage("O estado deve conter 2 letras maiúsculas (UF).");

            RuleFor(address => address.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Length(9).WithMessage("O CEP deve conter 9 dígitos.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP deve estar no formato 'XXXXX-XXX'.");
        }
    }
}
