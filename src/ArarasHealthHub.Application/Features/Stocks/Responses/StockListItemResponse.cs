using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record StockListItemResponse(
        int Id,
        int ProductId,
        string ProductName,
        decimal CurrentQuantity,
        decimal ReservedQuantity,
        decimal AvailableQuantity,
        decimal MinQuantity,
        decimal AverageCost,
        bool IsCritical,
        DateTime CreatedOn,
        DateTime? UpdatedOn
    );
}
