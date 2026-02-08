using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Commands.DeactivateFacility;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class DeactivateFacilityCommandValidator : AbstractValidator<DeactivateFacilityCommand>
    {
        public DeactivateFacilityCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.Facilities.AnyAsync(mc => mc.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.Facility));
        }
    }
}
