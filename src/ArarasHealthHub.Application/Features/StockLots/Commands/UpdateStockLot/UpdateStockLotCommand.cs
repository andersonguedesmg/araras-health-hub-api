using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot
{
    public record UpdateStockLotCommand(
        int StockId,
        decimal Quantity,
        string Batch,
        string Brand,
        decimal UnitValue,
        DateTime ExpiryDate,
        int SourceDocumentId,
        string SourceDocumentType
    ) : IRequest<ApiResponseO<StockLot>>;
}
