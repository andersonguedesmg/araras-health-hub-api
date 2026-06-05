using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public sealed record OrderItemResponse(
        int Id,
        int ProductId,
        string ProductName,
        decimal RequestedQuantity,
        decimal ApprovedQuantity,
        decimal ReservedQuantity,
        decimal ActualQuantity,
        decimal AvailableQuantity,
        IReadOnlyCollection<OrderItemLotResponse> Lots
    );
}
