using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class GetSubCategoryByIdQueryValidator : AbstractValidator<GetSubCategoryByIdQuery>
    {
        public GetSubCategoryByIdQueryValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.SubCategories.AnyAsync(sc => sc.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.SubCategory));
        }
    }
}
