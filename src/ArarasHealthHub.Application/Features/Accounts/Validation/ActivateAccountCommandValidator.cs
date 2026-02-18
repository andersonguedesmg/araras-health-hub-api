using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.ActivateAccount;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class ActivateAccountCommandValidator : AbstractValidator<ActivateAccountCommand>
    {
        public ActivateAccountCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId);
        }
    }
}
