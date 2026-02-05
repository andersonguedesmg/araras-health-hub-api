using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Commands.ActivatePresentationForm;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class ActivatePresentationFormCommandValidator : AbstractValidator<ActivatePresentationFormCommand>
    {
        public ActivatePresentationFormCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.PresentationForms.AnyAsync(p => p.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.PresentationForm));
        }
    }
}
