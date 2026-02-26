using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Commands.ActivateEmployee;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class ActivateEmployeeCommandValidator : AbstractValidator<ActivateEmployeeCommand>
    {
        public ActivateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
