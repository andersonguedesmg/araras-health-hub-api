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

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStocks
{
    public class GetStocksQueryHandler : IRequestHandler<GetStocksQuery, PagedResult<StockListItemResponse>>
    {
        private readonly IStockRepository _stockRepository;

        public GetStocksQueryHandler(
            IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<PagedResult<StockListItemResponse>> Handle(
            GetStocksQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Stock> query = _stockRepository
                .GetQueryable()
                .AsNoTracking()
                .Include(x => x.StockCost)
                .Include(x => x.Product)
                    .ThenInclude(x => x.MainCategory)
                .Include(x => x.Product)
                    .ThenInclude(x => x.SubCategory)
                .Include(x => x.Product)
                    .ThenInclude(x => x.PackagingType);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Product.Name, $"%{term}%") ||
                    EF.Functions.Like(x.Product.Description, $"%{term}%") ||
                    EF.Functions.Like(x.Product.MainCategory!.Name, $"%{term}%") ||
                    EF.Functions.Like(x.Product.SubCategory!.Name, $"%{term}%") ||
                    EF.Functions.Like(x.Product.PackagingType!.Name, $"%{term}%"));
            }

            var totalCount = await query
                .CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "productname" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Product.Name)
                    : query.OrderBy(x => x.Product.Name),

                "availablequantity" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.AvailableQuantity)
                    : query.OrderBy(x => x.AvailableQuantity),

                "minquantity" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.MinQuantity)
                    : query.OrderBy(x => x.MinQuantity),

                _ => query.OrderBy(x => x.Product.Name)
            };

            var items = await query
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
                    x.AvailableQuantity <= x.MinQuantity,
                    x.CreatedOn,
                    x.UpdatedOn))
                .ToListAsync(cancellationToken);

            return PagedResult<StockListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Estoques listados com sucesso.");
        }
    }
}
