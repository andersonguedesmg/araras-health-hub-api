using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public record OrderItemPickingResponse(
        int Id,
        int ProductId,
        string ProductName,
        decimal RequestedQuantity,
        decimal ApprovedQuantity)
    {
        public List<OrderItemLotPickingResponse> LotsToSeparate { get; set; } = [];
    }
}
