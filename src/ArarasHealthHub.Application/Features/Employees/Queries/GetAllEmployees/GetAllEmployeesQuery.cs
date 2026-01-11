using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : PagedRequest, IRequest<PagedResponse<EmployeeDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
