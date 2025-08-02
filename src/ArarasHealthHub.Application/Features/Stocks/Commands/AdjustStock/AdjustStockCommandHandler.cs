using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.AdjustStock
{
    public class AdjustStockCommandHandler : IRequestHandler<AdjustStockCommand, ApiResponse<bool>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockMovementRepository _stockMovementRepo;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdjustStockCommandHandler> _logger;

        public AdjustStockCommandHandler(
            IProductRepository productRepo,
            IEmployeeRepository employeeRepo,
            IStockMovementRepository stockMovementRepo,
            IStockAdjustmentRepository stockAdjustmentRepo,
            IUnitOfWork unitOfWork,
            ILogger<AdjustStockCommandHandler> logger)
        {
            _productRepo = productRepo;
            _employeeRepo = employeeRepo;
            _stockMovementRepo = stockMovementRepo;
            _stockAdjustmentRepo = stockAdjustmentRepo;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<bool>> Handle(AdjustStockCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdWithStockAsync(request.ProductId);
            if (product == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Produto"), false);
            }

            var responsible = await _employeeRepo.GetByIdAsync(request.AdjustedByEmployeeId);
            if (responsible == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), false);
            }

            if (product.Stock == null)
            {
                product.Stock = new Stock { ProductId = product.Id, CurrentQuantity = 0 };
            }

            if (request.Quantity < 0 && product.Stock.CurrentQuantity < -request.Quantity)
            {
                throw new ApplicationException($"Estoque insuficiente para o produto {product.Id}. Necessário: {-request.Quantity}, Disponível: {product.Stock.CurrentQuantity}.");
            }

            var stockAdjustment = new StockAdjustment
            {
                ProductId = product.Id,
                Quantity = request.Quantity,
                Reason = request.Reason,
                ResponsibleId = request.AdjustedByEmployeeId
            };
            await _stockAdjustmentRepo.AddAsync(stockAdjustment);

            var movement = new StockMovement
            {
                ProductId = product.Id,
                Quantity = request.Quantity,
                Type = MovementTypeEnum.Adjustment,
                SourceDocumentId = stockAdjustment.Id,
                SourceDocumentType = nameof(StockAdjustment),
                ResponsibleId = request.AdjustedByEmployeeId
            };

            product.Stock.CurrentQuantity += request.Quantity;
            product.Stock.SetUpdatedOn();
            await _stockMovementRepo.AddAsync(movement);
            await _unitOfWork.CommitAsync();

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.StockAdjustmentCompletedSuccessfully, true);
        }
    }
}
