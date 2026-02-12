using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Responses;
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
        List<CreateStockAdjustmentItemCommand> AdjustmentItems
    ) : IRequest<ApiResponseO<int>>, ITransactionalRequest;

    public record CreateStockAdjustmentItemCommand(
        int ProductId,
        decimal Quantity,
        string Batch,
        string Brand,
        DateTime? ExpiryDate,
        decimal? UnitValue
    );
}
