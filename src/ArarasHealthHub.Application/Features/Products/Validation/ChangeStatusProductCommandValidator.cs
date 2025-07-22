using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Commands.ChangeStatusProduct;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class ChangeStatusProductCommandValidator : AbstractValidator<ChangeStatusProductCommand>
    {
        public ChangeStatusProductCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID do produto é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
