using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class UpdateMainCategoryCommandValidator : AbstractValidator<UpdateMainCategoryCommand>
    {
        public UpdateMainCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId);

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100));
        }
    }
}
