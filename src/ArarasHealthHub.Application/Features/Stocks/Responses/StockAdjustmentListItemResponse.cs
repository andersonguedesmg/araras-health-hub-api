using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record StockAdjustmentListItemResponse(
        int Id,
        StockAdjustmentType Type,
        string Reason,
        DateTime AdjustmentDate,
        string ResponsibleName,
        int TotalItems
    );
}
