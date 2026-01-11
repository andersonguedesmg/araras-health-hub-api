using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Commands.ChangeStatusEmployee;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class ChangeStatusEmployeeCommandValidator : AbstractValidator<ChangeStatusEmployeeCommand>
    {
        public ChangeStatusEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador do funcionário é inválido.");
        }
    }
}
