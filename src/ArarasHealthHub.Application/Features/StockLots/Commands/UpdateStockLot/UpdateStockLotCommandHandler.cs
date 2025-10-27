using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockLots.Commands.UpdateStockLot
{
    public class UpdateStockLotCommandHandler : IRequestHandler<UpdateStockLotCommand, ApiResponse<StockLot>>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateStockLotCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<StockLot>> Handle(UpdateStockLotCommand request, CancellationToken cancellationToken)
        {
            var stockLot = await _dbContext.StockLots
                .FirstOrDefaultAsync(sl =>
                    sl.StockId == request.StockId &&
                    sl.Batch == request.Batch,
                    cancellationToken
                );

            if (stockLot == null)
            {
                stockLot = new StockLot
                {
                    StockId = request.StockId,
                    Batch = request.Batch,
                    UnitValue = request.UnitValue,
                    ExpiryDate = request.ExpiryDate,
                    AvailableQuantity = request.Quantity,
                    ReceivedItemId = request.ReceivedItemId,
                };
                await _dbContext.StockLots.AddAsync(stockLot, cancellationToken);
            }
            else
            {
                stockLot.AddQuantity(request.Quantity);
                _dbContext.StockLots.Update(stockLot);
            }

            return new ApiResponse<StockLot>(StatusCodes.Status200OK, "Lote de estoque atualizado com sucesso.", stockLot);
        }
    }
}
