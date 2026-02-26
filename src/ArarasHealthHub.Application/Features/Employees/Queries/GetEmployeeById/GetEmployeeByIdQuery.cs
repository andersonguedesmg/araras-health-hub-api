using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<Result<EmployeeResponse>>;
}
