using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithName("Usuário")
                    .WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithName("Senha")
                    .WithMessage(ValidationMessages.RequiredField);
        }
    }
}
