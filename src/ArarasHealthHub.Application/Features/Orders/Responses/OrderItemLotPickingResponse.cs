using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public record OrderItemLotPickingResponse(
        int StockLotId,
        string Batch,
        DateTime ExpiryDate,
        decimal QuantityToSeparate,
        decimal UnitValue
    );
}
