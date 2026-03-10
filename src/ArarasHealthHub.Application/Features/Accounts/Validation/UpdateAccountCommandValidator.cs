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
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Usuário é obrigatório.")
                .MinimumLength(3).WithMessage("Usuário deve ter pelo menos 3 caracteres.")
                .MaximumLength(256).WithMessage("Usuário não pode exceder 256 caracteres.");
        }
    }
}
