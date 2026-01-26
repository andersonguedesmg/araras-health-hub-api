using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class CreateMainCategoryCommandValidator : AbstractValidator<CreateMainCategoryCommand>
    {
        public CreateMainCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O nome não pode exceder 100 caracteres.");
        }
    }
}
