using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using FluentValidation;

namespace ArarasHealthHub.Application.Common.Validation
{
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        public ContactDtoValidator()
        {
            RuleFor(contact => contact.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O formato do email é inválido.")
                .MaximumLength(100).WithMessage("O email não pode exceder 100 caracteres.");

            RuleFor(contact => contact.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$").WithMessage("O formato do telefone é inválido.");
        }
    }
}
