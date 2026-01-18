using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees;
using ArarasHealthHub.Shared.Core.Pagination;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class GetAllEmployeesQueryValidator : PagedQueryValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.ToLower() is "name" or "cpf" or "function")
                .WithMessage("O campo de ordenação informado não é válido.");
        }
    }
}
