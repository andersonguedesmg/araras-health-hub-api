using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static ArarasHealthHub.Application.Services.StockAllocation.StockAllocationDtos;

namespace ArarasHealthHub.Application.Services.StockAllocation
{
    public class StockAllocationService : IStockAllocationService
    {
        private readonly IStockLotRepository _stockLotRepo;
        private readonly IStockRepository _stockRepo;
        private readonly IProductRepository _productRepo;
        private readonly IStockMovementRepository _stockMovementRepo;

        public StockAllocationService(
            IStockLotRepository stockLotRepo,
            IStockRepository stockRepo,
            IProductRepository productRepo,
            IStockMovementRepository stockMovementRepo)
        {
            _stockLotRepo = stockLotRepo;
            _stockRepo = stockRepo;
            _productRepo = productRepo;
            _stockMovementRepo = stockMovementRepo;
        }

        public async Task<ApiResponse<StockAllocationResult>> AllocateFeFo(int productId, decimal quantityToAllocate)
        {
            var availableLots = await _stockLotRepo.AsQueryable()
                .Include(sl => sl.Stock)
                .Where(sl =>
                    sl.Stock.ProductId == productId &&
                    sl.AvailableQuantity > 0 &&
                    sl.ExpiryDate >= DateTime.UtcNow)
                .OrderBy(sl => sl.ExpiryDate)
                .ThenBy(sl => sl.CreatedOn)
                .ToListAsync();

            var allocationDetails = new List<AllocatedLotDetail>();
            decimal remainingQuantity = quantityToAllocate;
            decimal totalAllocated = 0;

            foreach (var lot in availableLots)
            {
                if (remainingQuantity <= 0) break;

                decimal quantityFromThisLot = Math.Min(remainingQuantity, lot.AvailableQuantity);

                allocationDetails.Add(new AllocatedLotDetail(
                    StockLotId: lot.Id,
                    QuantityAllocated: quantityFromThisLot
                ));

                remainingQuantity -= quantityFromThisLot;
                totalAllocated += quantityFromThisLot;
            }

            var allocationResult = new StockAllocationResult(
                ProductId: productId,
                RequestedQuantity: quantityToAllocate,
                LotDetails: allocationDetails
            );

            if (!allocationResult.IsFullyAllocated)
            {
                var product = await _productRepo.GetByIdAsync(productId);
                var message = $"Não foi possível alocar {quantityToAllocate} unidades do produto {product?.Name}. Saldo encontrado: {totalAllocated}.";
                return new ApiResponse<StockAllocationResult>(StatusCodes.Status400BadRequest, message, false);
            }

            return new ApiResponse<StockAllocationResult>(StatusCodes.Status200OK, "Alocação FEFO concluída com sucesso.", allocationResult);
        }

        public async Task<List<StockMovement>> PerformStockExit(
            StockAllocationResult allocationResult,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType)
        {
            var movements = new List<StockMovement>();

            if (!allocationResult.LotDetails.Any()) return movements;

            var stock = await _stockRepo.GetByProductIdAsync(allocationResult.ProductId);

            if (stock == null) throw new ApplicationException($"Falha crítica: Estoque consolidado não encontrado para o Produto {allocationResult.ProductId}.");

            decimal totalQuantityToMove = 0;

            foreach (var detail in allocationResult.LotDetails)
            {
                var lot = await _stockLotRepo.GetByIdAsync(detail.StockLotId);

                if (lot == null) throw new ApplicationException($"Falha crítica: Lote de estoque (ID: {detail.StockLotId}) não encontrado durante a baixa.");

                lot.RemoveQuantity(detail.QuantityAllocated);
                _stockLotRepo.UpdateWithoutSaving(lot);

                movements.Add(new StockMovement
                {
                    StockLotId = lot.Id,
                    Quantity = detail.QuantityAllocated,
                    Type = MovementTypeEnum.Exit,
                    SourceDocumentId = sourceDocumentId,
                    SourceDocumentType = sourceDocumentType,
                    ResponsibleId = responsibleId
                });

                totalQuantityToMove += detail.QuantityAllocated;
            }

            stock.CurrentQuantity -= totalQuantityToMove;
            stock.AvailableQuantity -= totalQuantityToMove;
            stock.SetUpdatedOn();

            _stockRepo.UpdateWithoutSaving(stock);
            _stockMovementRepo.AddRangeWithoutSaving(movements);

            return movements;
        }
    }
}
