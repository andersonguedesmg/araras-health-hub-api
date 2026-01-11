using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(
        int Id,
        string Name,
        string Cpf,
        string Function,
        string Phone
    ) : IRequest<ApiResponse<bool>>
    {
        public UpdateEmployeeCommand WithId(int id)
            => this with { Id = id };
    }
}
