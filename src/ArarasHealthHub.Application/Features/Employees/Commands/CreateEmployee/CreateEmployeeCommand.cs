using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(
        string Name,
        string Cpf,
        string Function,
        string Phone
    ) : IRequest<ApiResponse<int>>;
}
