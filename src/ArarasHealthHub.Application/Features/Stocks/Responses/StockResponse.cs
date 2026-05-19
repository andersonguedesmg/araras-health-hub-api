using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record StockResponse(
        int Id,
        int ProductId,
        ProductResponse Product,
        decimal CurrentQuantity,
        decimal ReservedQuantity,
        decimal AvailableQuantity,
        decimal MinQuantity,
        decimal AverageCost,
        DateTime CreatedOn,
        DateTime? UpdatedOn
    );
}
