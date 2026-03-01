using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;

using FluentValidation;

namespace ArarasHealthHub.Application.Common.Validation
{
    public class AddressRequestValidator : AbstractValidator<Address>
    {
        public AddressRequestValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("A rua é obrigatória.")
                .MaximumLength(200).WithMessage("A rua deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O número é obrigatório.")
                .MaximumLength(20).WithMessage("O número deve ter no máximo 20 caracteres.");

            RuleFor(x => x.Complement)
                .MaximumLength(100).WithMessage("O complemento deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("O bairro é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro deve ter no máximo 100 caracteres.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade deve ter no máximo 100 caracteres.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve conter 2 caracteres.")
                .Matches("^[A-Z]{2}$").WithMessage("O estado deve conter 2 letras maiúsculas (UF).");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .Length(9).WithMessage("O CEP deve estar no formato XXXXX-XXX.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP deve estar no formato XXXXX-XXX.");
        }
    }
}
