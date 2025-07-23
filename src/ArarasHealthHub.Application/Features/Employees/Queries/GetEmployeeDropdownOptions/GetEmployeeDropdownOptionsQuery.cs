using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdownOptions
{
    public class GetEmployeeDropdownOptionsQuery : IRequest<ApiResponse<List<EmployeeNameDto>>> { }
}
