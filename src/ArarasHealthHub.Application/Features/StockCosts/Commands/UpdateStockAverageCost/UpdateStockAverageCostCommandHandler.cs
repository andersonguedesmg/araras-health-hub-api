using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockCosts.Commands.UpdateStockAverageCost
{
    public class UpdateStockAverageCostCommandHandler : IRequestHandler<UpdateStockAverageCostCommand, ApiResponse<StockCost>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IStockCostRepository _stockCostRepository;

        public UpdateStockAverageCostCommandHandler(IApplicationDbContext dbContext, IStockCostRepository stockCostRepository)
        {
            _dbContext = dbContext;
            _stockCostRepository = stockCostRepository;
        }

        public async Task<ApiResponse<StockCost>> Handle(UpdateStockAverageCostCommand request, CancellationToken cancellationToken)
        {
            if (request.EntryQuantity <= 0)
            {
                return new ApiResponse<StockCost>(StatusCodes.Status400BadRequest, ApiMessages.TheQuantityMustBeGreaterThanZero, false);
            }

            if (request.EntryUnitValue < 0)
            {
                return new ApiResponse<StockCost>(StatusCodes.Status400BadRequest, ApiMessages.TheUnitValueCannotBeNegative, false);
            }

            var currentStockQuantity = request.UpdatedStockQuantity;

            var stockCost = await _dbContext.StockCosts
                .FirstOrDefaultAsync(sc => sc.StockId == request.StockId, cancellationToken);

            if (stockCost == null)
            {
                stockCost = new StockCost
                {
                    StockId = request.StockId,
                    AverageUnitCost = request.EntryUnitValue,
                    CurrentTotalCost = request.EntryQuantity * request.EntryUnitValue
                };

                await _dbContext.StockCosts.AddAsync(stockCost, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return new ApiResponse<StockCost>(StatusCodes.Status200OK, ApiMessages.CostOfInventoryInitializedAndSavedSuccessfully, stockCost);
            }

            stockCost.Stock = null!;

            var oldQuantity = currentStockQuantity - request.EntryQuantity;

            if (oldQuantity <= 0)
            {
                stockCost.AverageUnitCost = request.EntryUnitValue;
                stockCost.CurrentTotalCost = request.EntryQuantity * request.EntryUnitValue;
            }
            else
            {
                var oldTotalCost = stockCost.CurrentTotalCost;
                var entryTotalCost = request.EntryQuantity * request.EntryUnitValue;
                var newTotalCost = oldTotalCost + entryTotalCost;
                var newQuantity = currentStockQuantity;

                stockCost.AverageUnitCost = newTotalCost / newQuantity;
                stockCost.CurrentTotalCost = newTotalCost;
            }

            _dbContext.StockCosts.Update(stockCost);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ApiResponse<StockCost>(StatusCodes.Status200OK, ApiMessages.WeightedAverageCostSuccessfullyUpdated, stockCost);
        }
    }
}
