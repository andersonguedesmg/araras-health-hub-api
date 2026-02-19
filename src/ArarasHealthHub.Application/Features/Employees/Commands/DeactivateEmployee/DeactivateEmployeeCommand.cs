using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.DeactivateEmployee
{
    public record DeactivateEmployeeCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivateEmployeeCommand WithId(int id)
            => this with { Id = id };
    }
}
