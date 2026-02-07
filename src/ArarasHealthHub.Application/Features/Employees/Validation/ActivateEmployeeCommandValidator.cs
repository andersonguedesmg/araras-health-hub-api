using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Commands.ActivateEmployee;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class ActivateEmployeeCommandValidator : AbstractValidator<ActivateEmployeeCommand>
    {
        public ActivateEmployeeCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId)
                .MustAsync(async (id, ct) =>
                    await context.Employees.AnyAsync(e => e.Id == id, ct))
                    .WithMessage(ApiMessages.EntityNotFound(EntityNames.Employee));
        }
    }
}
