using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByDirection
{
    public class GetMovementsByDirectionQueryHandler : IRequestHandler<GetMovementsByDirectionQuery, PagedResult<StockMovementListItemResponse>>
    {
        private readonly IStockMovementRepository _repository;

        public GetMovementsByDirectionQueryHandler(
            IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<StockMovementListItemResponse>> Handle(
            GetMovementsByDirectionQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<StockMovement> query = _repository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.StockLot)
                    .ThenInclude(x => x.Stock)
                        .ThenInclude(x => x.Product)
                .Include(x => x.Responsible)
                .Where(x => x.Direction == request.Direction);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderByDescending(x => x.MovementDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(m => new StockMovementListItemResponse(
                    m.Id,
                    m.StockLot.Stock.ProductId,
                    m.StockLot.Stock.Product.Name,
                    m.Quantity,
                    m.Direction,
                    m.Reason,
                    m.StockLot.Batch,
                    m.StockLot.Brand,
                    m.SourceDocumentId,
                    m.SourceDocumentType,
                    m.Responsible.Name,
                    m.MovementCost,
                    m.MovementDate))
                .ToListAsync(cancellationToken);

            return PagedResult<StockMovementListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Movimentações por direção listadas com sucesso.");
        }
    }
}
