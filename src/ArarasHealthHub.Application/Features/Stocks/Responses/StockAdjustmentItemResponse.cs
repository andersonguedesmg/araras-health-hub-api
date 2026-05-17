using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record StockAdjustmentItemResponse(
        int Id,
        int ProductId,
        ProductResponse Product,
        decimal Quantity,
        decimal? UnitValue,
        decimal? TotalValue,
        string? Batch,
        string? Brand,
        DateTime? ExpiryDate
    );
}
