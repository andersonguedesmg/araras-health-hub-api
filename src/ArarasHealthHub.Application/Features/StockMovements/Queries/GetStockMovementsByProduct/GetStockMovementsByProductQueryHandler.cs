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

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByProduct
{
    public class GetStockMovementsByProductQueryHandler : IRequestHandler<GetStockMovementsByProductQuery, PagedResult<StockMovementListItemResponse>>
    {
        private readonly IStockMovementRepository _repository;

        public GetStockMovementsByProductQueryHandler(
            IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<StockMovementListItemResponse>> Handle(
            GetStockMovementsByProductQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<StockMovement> query = _repository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.StockLot)
                    .ThenInclude(x => x.Stock)
                        .ThenInclude(x => x.Product)
                .Include(x => x.Responsible)
                .Where(x =>
                    x.StockLot.Stock.ProductId == request.ProductId);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.StockLot.Batch, $"%{term}%") ||
                    EF.Functions.Like(x.StockLot.Brand, $"%{term}%") ||
                    EF.Functions.Like(x.Responsible.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "movementdate" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.MovementDate)
                    : query.OrderBy(x => x.MovementDate),

                "direction" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Direction)
                    : query.OrderBy(x => x.Direction),

                _ => query.OrderByDescending(x => x.MovementDate)
            };

            var items = await query
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
                "Movimentações do produto listadas com sucesso.");
        }
    }
}
