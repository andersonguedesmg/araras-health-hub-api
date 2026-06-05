using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public record OrderPickingResponse(
        int Id,
        int OrderStatusId,
        string OrderStatus,
        int OrderFacilityId,
        string OrderFacility,
        DateTime CreatedAt,
        List<OrderItemPickingResponse> Items
    );
}
