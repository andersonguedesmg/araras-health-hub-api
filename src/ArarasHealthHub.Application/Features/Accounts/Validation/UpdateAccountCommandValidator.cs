using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("O ID do usuário é obrigatório e deve ser um número válido.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
                .Length(3, 150).WithMessage("O nome de usuário deve ter entre 3 e 150 caracteres.");
        }
    }
}
