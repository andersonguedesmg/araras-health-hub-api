using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Inventory.Adjustments
{
    public interface IInventoryAdjustmentService
    {
        Task<Result<int>> CreateAdjustmentAsync(
            CreateStockAdjustmentCommand command,
            CancellationToken cancellationToken);
    }
}
