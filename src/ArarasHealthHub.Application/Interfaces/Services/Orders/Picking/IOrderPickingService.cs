using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Picking
{
    public interface IOrderPickingService
    {
        Task<OrderPickingResponse> BuildPickingAsync(
            Order order,
            CancellationToken cancellationToken);
    }
}
