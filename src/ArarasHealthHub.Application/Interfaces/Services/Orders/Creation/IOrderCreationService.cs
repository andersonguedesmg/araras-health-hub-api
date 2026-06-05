using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Creation
{
    public interface IOrderCreationService
    {
        Task<Result<int>> CreateOrderAsync(
            CreateOrderCommand command,
            CancellationToken cancellationToken);
    }
}
