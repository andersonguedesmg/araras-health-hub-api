using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder
{
    public record FinalizeOrderCommand(
        int OrderId,
        int FinalizedByEmployeeId
    ) : IRequest<Result<int>>, ITransactionalRequest;
}
