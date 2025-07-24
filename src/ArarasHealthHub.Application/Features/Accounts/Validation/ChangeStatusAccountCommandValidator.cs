using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Commands.ChangeStatusAccount;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class ChangeStatusAccountCommandValidator : AbstractValidator<ChangeStatusAccountCommand>
    {
        public ChangeStatusAccountCommandValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("O ID da conta é obrigatório e deve ser um número válido maior que zero.");
        }
    }
}
