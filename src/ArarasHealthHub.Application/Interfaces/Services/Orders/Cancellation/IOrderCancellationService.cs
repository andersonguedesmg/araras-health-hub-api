using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Cancellation
{
    public interface IOrderCancellationService
    {
        Task<Result<int>> CancelAsync(
            CancelOrderCommand command,
            CancellationToken cancellationToken);
    }
}
