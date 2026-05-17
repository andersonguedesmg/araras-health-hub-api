using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record StockAdjustmentResponse(
        int Id,
        StockAdjustmentType Type,
        string Reason,
        string? Observation,
        DateTime AdjustmentDate,
        string ResponsibleName,
        string AccountUserName,
        IReadOnlyCollection<StockAdjustmentItemResponse> Items,
        DateTime CreatedOn,
        DateTime UpdatedOn
    );
}
