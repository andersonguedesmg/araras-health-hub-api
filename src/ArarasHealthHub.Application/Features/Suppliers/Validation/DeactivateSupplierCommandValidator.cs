using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Validation
{
    public class DeactivateSupplierCommandValidator : AbstractValidator<DeactivateSupplierCommand>
    {
        public DeactivateSupplierCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.Suppliers.AnyAsync(e => e.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.Supplier));
        }
    }
}
