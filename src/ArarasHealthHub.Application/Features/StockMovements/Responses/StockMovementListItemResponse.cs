using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.StockMovements.Responses
{
    public record StockMovementListItemResponse(
        int Id,
        int ProductId,
        string ProductName,
        decimal Quantity,
        MovementDirectionEnum Direction,
        MovementReasonEnum Reason,
        string Batch,
        string Brand,
        int SourceDocumentId,
        string SourceDocumentType,
        string ResponsibleName,
        decimal MovementCost,
        DateTime MovementDate
    );
}
