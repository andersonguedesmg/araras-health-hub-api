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

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements
{
    public class GetAllStockMovementsQueryHandler : IRequestHandler<GetAllStockMovementsQuery, PagedResult<StockMovementListItemResponse>>
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public GetAllStockMovementsQueryHandler(
            IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<PagedResult<StockMovementListItemResponse>> Handle(
            GetAllStockMovementsQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<StockMovement> query = _stockMovementRepository
                .AsQueryable()
                .AsNoTracking()
                .Include(m => m.StockLot)
                    .ThenInclude(sl => sl.Stock)
                        .ThenInclude(s => s.Product)
                .Include(m => m.Responsible);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(m =>
                    EF.Functions.Like(m.SourceDocumentType, $"%{term}%") ||
                    EF.Functions.Like(m.StockLot.Stock.Product.Name, $"%{term}%") ||
                    EF.Functions.Like(m.Responsible.Name, $"%{term}%") ||
                    EF.Functions.Like(m.StockLot.Batch, $"%{term}%") ||
                    EF.Functions.Like(m.StockLot.Brand, $"%{term}%"));
            }

            var totalCount = await query
                .CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "productname" => request.SortOrder == "desc"
                    ? query.OrderByDescending(m => m.StockLot.Stock.Product.Name)
                    : query.OrderBy(m => m.StockLot.Stock.Product.Name),

                "direction" => request.SortOrder == "desc"
                    ? query.OrderByDescending(m => m.Direction)
                    : query.OrderBy(m => m.Direction),

                "reason" => request.SortOrder == "desc"
                    ? query.OrderByDescending(m => m.Reason)
                    : query.OrderBy(m => m.Reason),

                "movementdate" => request.SortOrder == "desc"
                    ? query.OrderByDescending(m => m.MovementDate)
                    : query.OrderBy(m => m.MovementDate),

                "responsible" => request.SortOrder == "desc"
                    ? query.OrderByDescending(m => m.Responsible.Name)
                    : query.OrderBy(m => m.Responsible.Name),

                _ => query.OrderByDescending(m => m.CreatedOn)
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
                "Movimentações de estoque listadas com sucesso.");
        }
    }
}
