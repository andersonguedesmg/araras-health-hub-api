using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot
{
    public class UpdateStockLotCommandHandler : IRequestHandler<UpdateStockLotCommand, ApiResponseO<StockLot>>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateStockLotCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseO<StockLot>> Handle(UpdateStockLotCommand request, CancellationToken cancellationToken)
        {
            var stockLot = await _dbContext.StockLots
                .FirstOrDefaultAsync(sl =>
                    sl.StockId == request.StockId &&
                    sl.Batch == request.Batch &&
                    sl.Brand == request.Brand,
                    cancellationToken
                );

            if (stockLot == null)
            {
                stockLot = new StockLot
                {
                    StockId = request.StockId,
                    Batch = request.Batch,
                    Brand = request.Brand,
                    UnitValue = request.UnitValue,
                    ExpiryDate = request.ExpiryDate,
                    AvailableQuantity = request.Quantity,
                };
                await _dbContext.StockLots.AddAsync(stockLot, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                stockLot.UnitValue = request.UnitValue;
                stockLot.ExpiryDate = request.ExpiryDate;
                stockLot.AddQuantity(request.Quantity);
                _dbContext.StockLots.Update(stockLot);
            }

            return new ApiResponseO<StockLot>(StatusCodes.Status200OK, ApiMessages.StockBatchUpdatedSuccessfully, null);
        }
    }
}
