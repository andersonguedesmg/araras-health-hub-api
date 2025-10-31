using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock
{
    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, ApiResponse<Stock>>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateProductStockCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<Stock>> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == request.ProductId, cancellationToken);

            if (stock == null)
            {
                if (request.OperationType == StockOperationTypeEnum.Receipt || request.OperationType == StockOperationTypeEnum.Adjustment)
                {
                    stock = new Stock { ProductId = request.ProductId, CurrentQuantity = 0, MinQuantity = 0 };
                    _dbContext.Stocks.Add(stock);
                }
                else
                {
                    return new ApiResponse<Stock>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Estoque do Produto", request.ProductId), false);
                }
            }

            switch (request.OperationType)
            {
                case StockOperationTypeEnum.Receipt:
                case StockOperationTypeEnum.Adjustment:
                    stock.CurrentQuantity += request.Quantity;
                    break;
                case StockOperationTypeEnum.Dispatch:
                    if (stock.CurrentQuantity < request.Quantity)
                    {
                        throw new ApplicationException($"Estoque insuficiente para o produto {request.ProductId}.");
                    }
                    stock.CurrentQuantity -= request.Quantity;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(request.OperationType), request.OperationType, "Tipo de operação de estoque não suportado.");
            }

            stock.SetUpdatedOn();

            return new ApiResponse<Stock>(StatusCodes.Status200OK, ApiMessages.ProductStockUpdatedSuccessfully, stock);
        }
    }
}
