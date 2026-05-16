using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment
{
    public record CreateStockAdjustmentCommand(
        StockAdjustmentType Type,
        string Reason,
        string? Observation,
        DateTime AdjustmentDate,
        int ResponsibleId,
        int AccountId,
        List<CreateStockAdjustmentItemCommand> Items
    ) : IRequest<Result<int>>;

    public record CreateStockAdjustmentItemCommand(
        int ProductId,
        decimal Quantity,
        string Batch,
        string Brand,
        DateTime? ExpiryDate,
        decimal? UnitValue
    );
}
