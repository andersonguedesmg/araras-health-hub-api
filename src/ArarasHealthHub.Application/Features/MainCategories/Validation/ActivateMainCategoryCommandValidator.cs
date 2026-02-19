using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Commands.ActivateMainCategory;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class ActivateMainCategoryCommandValidator : AbstractValidator<ActivateMainCategoryCommand>
    {
        public ActivateMainCategoryCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.MainCategories.AnyAsync(mc => mc.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.MainCategory));
        }
    }
}
