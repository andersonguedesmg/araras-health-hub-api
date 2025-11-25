using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Events
{
    public record OrderItemsSeparatedEvent(
        int OrderId,
        List<(int ProductId, decimal QuantityToRelease)> ReservedItemsReleased
    ) : INotification;
}
