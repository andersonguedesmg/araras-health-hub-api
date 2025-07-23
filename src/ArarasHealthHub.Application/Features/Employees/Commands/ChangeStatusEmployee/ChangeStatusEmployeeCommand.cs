using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.ChangeStatusEmployee
{
    public record ChangeStatusEmployeeCommand(
        int Id,
        bool IsActive
    ) : IRequest<ApiResponse<bool>>;
}
