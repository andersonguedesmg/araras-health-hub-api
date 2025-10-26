using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
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
            ICollection<AdjustmentItemCommand> AdjustmentItems
        ) : IRequest<ApiResponse<int>>, ITransactionalRequest;

    public record AdjustmentItemCommand(
        int ProductId,
        decimal Quantity,
        decimal? UnitValue,
        string? Batch,
        DateTime? ExpiryDate
    );
}
