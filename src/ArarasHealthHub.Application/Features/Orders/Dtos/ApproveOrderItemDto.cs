using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public record ApproveOrderItemDto(
        int OrderItemId,
        int ApprovedQuantity
    );
}
