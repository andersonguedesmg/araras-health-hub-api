using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Inventory.Adjustments;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment
{
    public class CreateStockAdjustmentCommandHandler : IRequestHandler<CreateStockAdjustmentCommand, Result<int>>
    {
        private readonly IInventoryAdjustmentService _inventoryAdjustmentService;

        public CreateStockAdjustmentCommandHandler(IInventoryAdjustmentService inventoryAdjustmentService)
        {
            _inventoryAdjustmentService = inventoryAdjustmentService;
        }

        public async Task<Result<int>> Handle(
            CreateStockAdjustmentCommand request,
            CancellationToken cancellationToken)
        {
            return await _inventoryAdjustmentService.CreateAdjustmentAsync(
                    request,
                    cancellationToken);
        }
    }
}
