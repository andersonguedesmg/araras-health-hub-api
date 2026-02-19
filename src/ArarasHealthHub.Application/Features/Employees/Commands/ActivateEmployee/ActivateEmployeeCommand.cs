using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.ActivateEmployee
{
    public record ActivateEmployeeCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivateEmployeeCommand WithId(int id)
            => this with { Id = id };
    }
}
