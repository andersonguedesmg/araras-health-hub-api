using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Commands.DeactivateAccount;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class DeactivateAccountCommandValidator : AbstractValidator<DeactivateAccountCommand>
    {
        public DeactivateAccountCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
