using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.ActivateEmployee
{
    public sealed record ActivateEmployeeCommand(int Id) : IRequest<Result>;
}
