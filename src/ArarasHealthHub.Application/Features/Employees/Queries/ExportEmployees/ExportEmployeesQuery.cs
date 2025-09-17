using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.ExportEmployees
{
    public class ExportEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
