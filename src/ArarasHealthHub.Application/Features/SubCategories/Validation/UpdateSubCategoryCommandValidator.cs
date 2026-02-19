using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class UpdateSubCategoryCommandValidator : AbstractValidator<UpdateSubCategoryCommand>
    {
        public UpdateSubCategoryCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.GreaterThanZeroField);

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100));

            RuleFor(x => x.MainCategoryId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.GreaterThanZeroField)
                .MustAsync(async (id, ct) =>
                    await context.MainCategories.AnyAsync(c => c.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.MainCategory));

            RuleFor(x => x)
                .MustAsync(async (command, ct) =>
                    !await context.SubCategories.AnyAsync(sc =>
                        sc.Id != command.Id &&
                        sc.MainCategoryId == command.MainCategoryId &&
                        sc.Name == command.Name,
                        ct))
                .WithMessage(ApiMessages.EntityAlreadyExists(EntityNames.SubCategory));
        }
    }
}
