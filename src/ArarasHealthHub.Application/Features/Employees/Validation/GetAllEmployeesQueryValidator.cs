using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class GetAllEmployeesQueryValidator : PagedRequestValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.Equals("name", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("cpf", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("function", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
