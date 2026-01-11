using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeById
{
    public record GetEmployeeByIdQuery(int Id) : IRequest<ApiResponse<EmployeeDto>>
    {
        public GetEmployeeByIdQuery WithId(int id)
            => this with { Id = id };
    }
}
