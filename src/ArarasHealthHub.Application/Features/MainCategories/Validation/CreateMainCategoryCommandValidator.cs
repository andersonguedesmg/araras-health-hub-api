using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class CreateMainCategoryCommandValidator : AbstractValidator<CreateMainCategoryCommand>
    {
        public CreateMainCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredWithField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthWithField(100));
        }
    }
}
