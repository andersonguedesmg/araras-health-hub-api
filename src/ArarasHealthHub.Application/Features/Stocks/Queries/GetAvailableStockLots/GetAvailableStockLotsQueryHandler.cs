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

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAvailableStockLots
{
    public class GetAvailableStockLotsQueryHandler : IRequestHandler<GetAvailableStockLotsQuery, PagedResult<StockLotListItemResponse>>
    {
        private readonly IStockLotRepository _stockLotRepository;

        public GetAvailableStockLotsQueryHandler(
            IStockLotRepository stockLotRepository)
        {
            _stockLotRepository = stockLotRepository;
        }

        public async Task<PagedResult<StockLotListItemResponse>> Handle(
            GetAvailableStockLotsQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<StockLot> query = _stockLotRepository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Stock)
                    .ThenInclude(x => x.Product)
                .Where(x => x.AvailableQuantity > 0);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Batch, $"%{term}%") ||
                    EF.Functions.Like(x.Brand, $"%{term}%") ||
                    EF.Functions.Like(x.Stock.Product.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "expirydate" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.ExpiryDate)
                    : query.OrderBy(x => x.ExpiryDate),

                "productname" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Stock.Product.Name)
                    : query.OrderBy(x => x.Stock.Product.Name),

                _ => query
                    .OrderBy(x => x.Stock.Product.Name)
                    .ThenBy(x => x.ExpiryDate)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new StockLotListItemResponse(
                    x.Id,
                    x.Stock.ProductId,
                    x.Stock.Product.Name,
                    x.Batch,
                    x.Brand,
                    x.AvailableQuantity,
                    x.UnitValue,
                    x.ExpiryDate))
                .ToListAsync(cancellationToken);

            return PagedResult<StockLotListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Lotes disponíveis listados com sucesso.");
        }
    }
}
