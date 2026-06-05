using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Separation
{
    public interface IOrderSeparationService
    {
        Task<Result<int>> SeparateAsync(
            SeparateOrderCommand command,
            CancellationToken cancellationToken);
    }
}
