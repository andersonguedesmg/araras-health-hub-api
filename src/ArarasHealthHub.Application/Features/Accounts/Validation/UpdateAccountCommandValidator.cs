using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId);

            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithName("Usuário")
                    .WithMessage(ValidationMessages.RequiredField)
                .MinimumLength(3)
                    .WithMessage(ValidationMessages.MinLengthField(3))
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100));
        }
    }
}
