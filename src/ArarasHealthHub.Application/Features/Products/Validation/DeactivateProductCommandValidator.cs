using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Commands.DeactivateProduct;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class DeactivateProductCommandValidator : AbstractValidator<DeactivateProductCommand>
    {
        public DeactivateProductCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.Products.AnyAsync(p => p.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.Product));
        }
    }
}
