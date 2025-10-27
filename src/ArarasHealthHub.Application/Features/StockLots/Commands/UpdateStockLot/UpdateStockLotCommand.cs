using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot
{
    public record UpdateStockLotCommand(
        int StockId,
        decimal Quantity,
        string Batch,
        decimal UnitValue,
        DateTime ExpiryDate,
        int ReceivedItemId
    ) : IRequest<ApiResponse<StockLot>>;
}
