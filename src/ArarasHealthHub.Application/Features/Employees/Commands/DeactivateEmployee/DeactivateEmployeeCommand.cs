using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.DeactivateEmployee
{
    public sealed record DeactivateEmployeeCommand(int Id) : IRequest<Result>;
}
