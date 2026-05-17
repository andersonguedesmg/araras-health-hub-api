using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById
{
    public class GetStockMovementByIdQueryHandler : IRequestHandler<GetStockMovementByIdQuery, Result<StockMovementResponse>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public GetStockMovementByIdQueryHandler(
            IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<Result<StockMovementResponse>> Handle(
            GetStockMovementByIdQuery request,
            CancellationToken cancellationToken)
        {
            var movement = await _stockMovementRepository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.StockLot)
                    .ThenInclude(x => x.Stock)
                        .ThenInclude(x => x.Product)
                .Include(x => x.Responsible)
                .FirstOrDefaultAsync(
                    x => x.Id == request.Id,
                    cancellationToken);

            if (movement is null)
            {
                throw new NotFoundException(
                    "Movimentação de estoque não encontrada.");
            }

            var response = new StockMovementResponse(
                movement.Id,
                movement.StockLotId,
                movement.StockLot.Stock.ProductId,
                movement.StockLot.Stock.Product.Name,
                movement.Quantity,
                movement.Direction,
                movement.Reason,
                movement.SourceDocumentId,
                movement.SourceDocumentType,
                movement.Responsible.Name,
                movement.StockLot.Batch,
                movement.StockLot.Brand,
                movement.StockLot.ExpiryDate,
                movement.MovementCost,
                movement.MovementDate,
                movement.CreatedOn
            );

            return Result<StockMovementResponse>.Success(
                response,
                "Movimentação encontrada com sucesso.");
        }
    }
}
