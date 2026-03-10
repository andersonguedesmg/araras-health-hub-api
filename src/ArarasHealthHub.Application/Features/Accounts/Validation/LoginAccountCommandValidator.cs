using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Usuário é obrigatório.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Senha é obrigatória.");
        }
    }
}
