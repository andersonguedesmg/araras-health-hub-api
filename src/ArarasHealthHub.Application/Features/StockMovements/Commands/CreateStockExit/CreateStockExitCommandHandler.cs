using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockExit
{
    public class CreateStockExitCommandHandler : IRequestHandler<CreateStockExitCommand, ApiResponse<StockMovementDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IStockCostRepository _stockCostRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateStockExitCommandHandler(
            IApplicationDbContext dbContext,
            IStockMovementRepository stockMovementRepository,
            IStockCostRepository stockCostRepository,
            IMediator mediator,
            IMapper mapper
        )
        {
            _dbContext = dbContext;
            _stockMovementRepository = stockMovementRepository;
            _stockCostRepository = stockCostRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ApiResponse<StockMovementDto>> Handle(CreateStockExitCommand request, CancellationToken cancellationToken)
        {
            var stockLot = await _dbContext.StockLots
                .Include(sl => sl.Stock)
                .FirstOrDefaultAsync(sl => sl.Id == request.StockLotId, cancellationToken);

            if (stockLot == null)
            {
                return new ApiResponse<StockMovementDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound($"Lote de Estoque com ID {request.StockLotId}"), null);
            }

            if (stockLot.AvailableQuantity < request.Quantity)
            {
                return new ApiResponse<StockMovementDto>(
                    StatusCodes.Status400BadRequest,
                    $"Quantidade insuficiente no Lote {stockLot.Batch}. Necessário: {request.Quantity}, Disponível: {stockLot.AvailableQuantity}.",
                    null
                );
            }

            var stockCost = await _stockCostRepository.GetByStockIdAsync(stockLot.Stock.Id);

            decimal averageUnitCost = stockCost?.AverageUnitCost ?? 0M;
            decimal exitCost = request.Quantity * averageUnitCost;

            stockLot.RemoveQuantity(request.Quantity);
            _dbContext.Set<StockLot>().Update(stockLot);

            if (stockCost != null)
            {
                stockCost.CurrentTotalCost -= exitCost;
                _dbContext.StockCosts.Update(stockCost);
            }

            var stockMovement = new StockMovement
            {
                StockLotId = request.StockLotId,
                Quantity = request.Quantity,
                Type = MovementTypeEnum.Exit,
                SourceDocumentId = request.SourceDocumentId,
                SourceDocumentType = request.SourceDocumentType,
                ResponsibleId = request.ResponsibleId,
                MovementCost = exitCost,
            };

            await _stockMovementRepository.AddWithoutSavingAsync(stockMovement);

            var updateCommand = new UpdateProductStockCommand(
                stockLot.Stock.ProductId,
                request.Quantity,
                StockOperationTypeEnum.Dispatch
            );
            await _mediator.Send(updateCommand, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            stockMovement.StockLot = stockLot;
            var responsible = await _dbContext.Users
                .OfType<Employee>()
                .FirstOrDefaultAsync(e => e.Id == request.ResponsibleId, cancellationToken);


            if (responsible == null)
            {
                throw new InvalidOperationException($"O Responsável com ID {request.ResponsibleId} não foi encontrado durante o processamento da movimentação.");
            }

            stockMovement.Responsible = responsible;

            var stockMovementDto = _mapper.Map<StockMovementDto>(stockMovement);
            return new ApiResponse<StockMovementDto>(StatusCodes.Status201Created, ApiMessages.RegisteredSuccessfully("Saída de estoque"), stockMovementDto);
        }
    }
}
