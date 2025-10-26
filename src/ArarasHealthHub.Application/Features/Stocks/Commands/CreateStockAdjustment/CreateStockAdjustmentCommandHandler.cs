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

namespace ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment
{
    public class CreateStockAdjustmentCommandHandler : IRequestHandler<CreateStockAdjustmentCommand, ApiResponse<int>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IStockMovementRepository _stockMovementRepo;
        private readonly IStockAdjustmentRepository _stockAdjustmentRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateStockAdjustmentCommandHandler> _logger;

        public CreateStockAdjustmentCommandHandler(
            IProductRepository productRepo,
            IEmployeeRepository employeeRepo,
            IStockMovementRepository stockMovementRepo,
            IStockAdjustmentRepository stockAdjustmentRepo,
            IUnitOfWork unitOfWork,
            ILogger<CreateStockAdjustmentCommandHandler> logger)
        {
            _productRepo = productRepo;
            _employeeRepo = employeeRepo;
            _stockMovementRepo = stockMovementRepo;
            _stockAdjustmentRepo = stockAdjustmentRepo;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<int>> Handle(CreateStockAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var responsible = await _employeeRepo.GetByIdAsync(request.ResponsibleId);
            if (responsible == null)
            {
                return new ApiResponse<int>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Responsável"), 0);
            }

            var adjustment = new StockAdjustment
            {
                Type = request.Type,
                Reason = request.Reason,
                Observation = request.Observation,
                AdjustmentDate = DateTime.UtcNow,
                ResponsibleId = request.ResponsibleId,
                AccountId = request.AccountId,
            };

            var newMovements = new List<StockMovement>();
            var movementQuantityMultiplier = (request.Type == StockAdjustmentType.Negative) ? -1 : 1;

            foreach (var itemCommand in request.AdjustmentItems)
            {
                var product = await _productRepo.GetByIdWithStockAsync(itemCommand.ProductId);
                if (product == null)
                {
                    return new ApiResponse<int>(StatusCodes.Status404NotFound, ApiMessages.NotFound($"Produto com ID {itemCommand.ProductId}"), 0);
                }

                var adjustedQuantity = itemCommand.Quantity * movementQuantityMultiplier;
                product.Stock ??= new Stock { ProductId = product.Id, CurrentQuantity = 0 };

                if (adjustedQuantity < 0)
                {
                    if (product.Stock.CurrentQuantity < -adjustedQuantity)
                    {
                        throw new ApplicationException($"Estoque insuficiente para o produto {product.Id} ({product.Name}). Necessário: {-adjustedQuantity}, Disponível: {product.Stock.CurrentQuantity}.");
                    }
                }

                adjustment.AdjustmentItems.Add(new StockAdjustmentItem
                {
                    ProductId = itemCommand.ProductId,
                    Quantity = itemCommand.Quantity,
                    UnitValue = itemCommand.UnitValue,
                    Batch = itemCommand.Batch,
                    ExpiryDate = itemCommand.ExpiryDate,
                });

                product.Stock.CurrentQuantity += adjustedQuantity;
                product.Stock.SetUpdatedOn();

                var movement = new StockMovement
                {
                    ProductId = product.Id,
                    Quantity = adjustedQuantity,
                    Type = MovementTypeEnum.Adjustment,
                    SourceDocumentId = 0,
                    SourceDocumentType = nameof(StockAdjustment),
                    ResponsibleId = request.ResponsibleId
                };

                newMovements.Add(movement);
            }

            await _stockAdjustmentRepo.AddAsync(adjustment);
            await _unitOfWork.CommitAsync();

            foreach (var movement in newMovements)
            {
                movement.SourceDocumentId = adjustment.Id;
                await _stockMovementRepo.AddAsync(movement);
            }

            await _unitOfWork.CommitAsync();

            return new ApiResponse<int>(StatusCodes.Status200OK, ApiMessages.StockAdjustmentCompletedSuccessfully, adjustment.Id);
        }
    }
}
