using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost
{
    public record UpdateStockAverageCostCommand(
        int StockId,
        decimal EntryQuantity,
        decimal EntryUnitValue,
        decimal UpdatedStockQuantity
    ) : IRequest<ApiResponseO<StockCost>>;
}
