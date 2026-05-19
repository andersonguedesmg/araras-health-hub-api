using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record StockLotNearExpiryListItemResponse(
        int StockLotId,
        int ProductId,
        string ProductName,
        string Batch,
        string Brand,
        decimal AvailableQuantity,
        DateTime ExpiryDate,
        int DaysRemaining,
        DateTime CreatedOn,
        DateTime? UpdatedOn
    );
}
