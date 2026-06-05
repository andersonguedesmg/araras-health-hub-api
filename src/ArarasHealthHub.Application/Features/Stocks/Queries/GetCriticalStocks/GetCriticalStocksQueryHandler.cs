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

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStocks
{
    public class GetCriticalStocksQueryHandler : IRequestHandler<GetCriticalStocksQuery, PagedResult<StockListItemResponse>>
    {
        private readonly IStockRepository _stockRepository;

        public GetCriticalStocksQueryHandler(
            IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<PagedResult<StockListItemResponse>> Handle(
            GetCriticalStocksQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Stock> query = _stockRepository
                .GetLowStockQueryable()
                .AsNoTracking()
                .Include(x => x.Product)
                .Include(x => x.StockCost);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Product.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(x => x.Product.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new StockListItemResponse(
                    x.Id,
                    x.ProductId,
                    x.Product.Name,
                    x.CurrentQuantity,
                    x.ReservedQuantity,
                    x.AvailableQuantity,
                    x.MinQuantity,
                    x.StockCost != null ? x.StockCost.AverageUnitCost : 0,
                    true,
                    x.CreatedOn,
                    x.UpdatedOn
                ))
                .ToListAsync(cancellationToken);

            return PagedResult<StockListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Estoques críticos listados com sucesso.");
        }
    }
}
