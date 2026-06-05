using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public sealed record OrderItemLotResponse(
        int StockLotId,
        string Batch,
        string Brand,
        DateTime ExpiryDate,
        decimal Quantity,
        decimal UnitValue,
        decimal TotalValue
    );
}
