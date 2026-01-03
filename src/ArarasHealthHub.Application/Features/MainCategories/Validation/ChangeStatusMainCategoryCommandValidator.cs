using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Commands.ChangeStatusMainCategory;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class ChangeStatusMainCategoryCommandValidator : AbstractValidator<ChangeStatusMainCategoryCommand>
    {
        public ChangeStatusMainCategoryCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID da categoria principal é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
