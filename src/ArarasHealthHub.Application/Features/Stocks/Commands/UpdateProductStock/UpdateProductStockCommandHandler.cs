using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock
{
    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, ApiResponseO<Stock>>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateProductStockCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseO<Stock>> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Stocks
                .FirstOrDefaultAsync(s => s.ProductId == request.ProductId, cancellationToken);

            bool isNewStock = (stock == null);

            if (isNewStock)
            {
                if (request.OperationType == StockOperationTypeEnum.Receipt || request.OperationType == StockOperationTypeEnum.Adjustment)
                {
                    stock = new Stock
                    {
                        ProductId = request.ProductId,
                        CurrentQuantity = 0,
                        AvailableQuantity = 0,
                        MinQuantity = 0
                    };
                    _dbContext.Stocks.Add(stock);

                    await _dbContext.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    return new ApiResponseO<Stock>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Estoque do Produto", request.ProductId), false);
                }
            }

            switch (request.OperationType)
            {
                case StockOperationTypeEnum.Receipt:
                case StockOperationTypeEnum.Adjustment:
                    stock!.CurrentQuantity += request.Quantity;
                    stock!.AvailableQuantity += request.Quantity;
                    break;
                case StockOperationTypeEnum.Dispatch:
                    if (stock!.AvailableQuantity < request.Quantity)
                    {
                        throw new ApplicationException($"Estoque disponível insuficiente para o produto {request.ProductId}. Quantidade requerida: {request.Quantity}, disponível: {stock.AvailableQuantity}.");
                    }

                    stock.CurrentQuantity -= request.Quantity;
                    stock.AvailableQuantity -= request.Quantity;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(request.OperationType), request.OperationType, "Tipo de operação de estoque não suportado.");
            }

            stock.SetUpdatedOn();

            return new ApiResponseO<Stock>(StatusCodes.Status200OK, ApiMessages.ProductStockUpdatedSuccessfully, stock);
        }
    }
}
