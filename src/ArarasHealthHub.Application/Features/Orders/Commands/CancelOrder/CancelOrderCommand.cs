using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder
{
    public record CancelOrderCommand(
        int OrderId,
        int CanceledByEmployeeId,
        string CancellationReason
    ) : IRequest<Result<int>>, ITransactionalRequest;
}
