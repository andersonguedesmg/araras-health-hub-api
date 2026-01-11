using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.DeleteEmployee
{
    public record DeleteEmployeeCommand(int Id) : IRequest<ApiResponse<bool>>
    {
        public DeleteEmployeeCommand WithId(int id)
            => this with { Id = id };
    }
}
