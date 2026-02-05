using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryById;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class GetMainCategoryByIdQueryValidator : AbstractValidator<GetMainCategoryByIdQuery>
    {
        public GetMainCategoryByIdQueryValidator(IApplicationDbContext context)
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
