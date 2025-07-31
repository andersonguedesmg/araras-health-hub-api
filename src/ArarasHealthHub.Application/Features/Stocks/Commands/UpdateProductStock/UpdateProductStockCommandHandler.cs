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
using Microsoft.Extensions.Logging;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock
{
    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, ApiResponse<bool>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateProductStockCommandHandler> _logger;

        public UpdateProductStockCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateProductStockCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando atualização de estoque para o produto {ProductId} - Operação: {OperationType}, Quantidade: {Quantity}",
                                   request.ProductId, request.OperationType, request.Quantity);

            var product = await _dbContext.Products
                                          .Include(p => p.Stock)
                                          .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

            if (product == null)
            {
                _logger.LogWarning("Produto com ID {ProductId} não encontrado para atualização de estoque.", request.ProductId);
                return new ApiResponse<bool>(
                    StatusCodes.Status404NotFound,
                    $"Produto com ID {request.ProductId} não encontrado.",
                    false
                );
            }

            if (product.Stock == null)
            {
                product.Stock = new Stock { ProductId = product.Id, CurrentQuantity = 0 };
                product.Stock.SetUpdatedOn();
                _dbContext.Stocks.Add(product.Stock);
            }

            switch (request.OperationType)
            {
                case StockOperationTypeEnum.Receipt:
                    product.Stock.CurrentQuantity += request.Quantity;
                    _logger.LogInformation("Estoque do produto {ProductId} atualizado para Recebimento. Nova quantidade: {NewQuantity}", product.Id, product.Stock.CurrentQuantity);
                    break;
                case StockOperationTypeEnum.Dispatch:
                    if (product.Stock.CurrentQuantity < request.Quantity)
                    {
                        _logger.LogError("Estoque insuficiente para o produto {ProductId}. Necessário: {RequiredQuantity}, Disponível: {AvailableQuantity}", product.Id, request.Quantity, product.Stock.CurrentQuantity);
                        throw new ApplicationException($"Estoque insuficiente para o produto {product.Id}. Necessário: {request.Quantity}, Disponível: {product.Stock.CurrentQuantity}.");
                    }
                    product.Stock.CurrentQuantity -= request.Quantity;
                    _logger.LogInformation("Estoque do produto {ProductId} atualizado para Saída. Nova quantidade: {NewQuantity}", product.Id, product.Stock.CurrentQuantity);
                    break;
                case StockOperationTypeEnum.Adjustment:
                    product.Stock.CurrentQuantity += request.Quantity;
                    _logger.LogInformation("Estoque do produto {ProductId} atualizado para Ajuste. Nova quantidade: {NewQuantity}", product.Id, product.Stock.CurrentQuantity);
                    break;
                default:
                    _logger.LogError("Tipo de operação de estoque desconhecido: {OperationType}", request.OperationType);
                    throw new ArgumentOutOfRangeException(nameof(request.OperationType), request.OperationType, "Tipo de operação de estoque não suportado.");
            }

            product.Stock.SetUpdatedOn();

            _logger.LogInformation("Atualização de estoque do produto {ProductId} processada com sucesso. Nova Quantidade: {NewQuantity}", product.Id, product.Stock.CurrentQuantity);
            return new ApiResponse<bool>(StatusCodes.Status200OK, "Estoque do produto atualizado com sucesso.", true);
        }
    }
}
