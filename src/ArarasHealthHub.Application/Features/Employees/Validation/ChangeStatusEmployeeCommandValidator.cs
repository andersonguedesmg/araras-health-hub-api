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
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID do funcionário é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
