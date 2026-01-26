using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Commands.DeleteMainCategory;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class DeleteMainCategoryCommandValidator : AbstractValidator<DeleteMainCategoryCommand>
    {
        public DeleteMainCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador da categoria principal é inválido.");
        }
    }
}
