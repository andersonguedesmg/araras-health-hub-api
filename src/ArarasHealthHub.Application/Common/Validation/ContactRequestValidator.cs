using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;

using FluentValidation;

namespace ArarasHealthHub.Application.Common.Validation
{
    public class ContactRequestValidator : AbstractValidator<Contact>
    {
        public ContactRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O formato do e-mail é inválido.")
                .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone deve ter no máximo 20 caracteres.");
        }
    }
}
