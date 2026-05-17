using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.StockMovements.Responses
{
    public record StockMovementResponse(
        int Id,
        int StockLotId,
        int ProductId,
        string ProductName,
        decimal Quantity,
        MovementDirectionEnum Direction,
        MovementReasonEnum Reason,
        int SourceDocumentId,
        string SourceDocumentType,
        string ResponsibleName,
        string Batch,
        string Brand,
        DateTime ExpiryDate,
        decimal MovementCost,
        DateTime MovementDate,
        DateTime CreatedOn
    );
}
