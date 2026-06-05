using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public sealed record OrderListItemResponse(
        int Id,
        int OrderStatusId,
        string OrderStatus,
        int OrderFacilityId,
        string OrderFacility,
        int CreatedByEmployeeId,
        string CreatedByEmployee,
        int ItemCount,
        DateTime CreatedOn,
        bool IsActive
    );
}
