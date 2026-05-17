using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments
{
    public class GetAllStockAdjustmentsQueryHandler : IRequestHandler<GetAllStockAdjustmentsQuery, PagedResult<StockAdjustmentListItemResponse>>
    {
        private readonly IStockAdjustmentRepository _repository;

        public GetAllStockAdjustmentsQueryHandler(
            IStockAdjustmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<StockAdjustmentListItemResponse>> Handle(
            GetAllStockAdjustmentsQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<StockAdjustment> query = _repository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Responsible)
                .Include(x => x.Account)
                .Include(x => x.Items);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Reason, $"%{term}%") ||
                    EF.Functions.Like(x.Responsible.Name, $"%{term}%") ||
                    x.Items.Any(i =>
                        EF.Functions.Like(i.Product.Name, $"%{term}%")));
            }

            var totalCount = await query
                .CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "type" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Type)
                    : query.OrderBy(x => x.Type),

                "reason" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Reason)
                    : query.OrderBy(x => x.Reason),

                "adjustmentdate" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.AdjustmentDate)
                    : query.OrderBy(x => x.AdjustmentDate),

                "responsible" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Responsible.Name)
                    : query.OrderBy(x => x.Responsible.Name),

                _ => query.OrderByDescending(x => x.CreatedOn)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new StockAdjustmentListItemResponse(
                    x.Id,
                    x.Type,
                    x.Reason,
                    x.AdjustmentDate,
                    x.Responsible.Name,
                    x.Items.Count))
                .ToListAsync(cancellationToken);

            return PagedResult<StockAdjustmentListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Ajustes de estoque listados com sucesso.");
        }
    }
}
