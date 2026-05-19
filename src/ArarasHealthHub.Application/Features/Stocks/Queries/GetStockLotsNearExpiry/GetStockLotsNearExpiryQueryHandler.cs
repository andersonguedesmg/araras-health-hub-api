using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Interfaces.Providers;
using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockLotsNearExpiry
{
    public class GetStockLotsNearExpiryQueryHandler : IRequestHandler<GetStockLotsNearExpiryQuery, PagedResult<StockLotNearExpiryListItemResponse>>
    {
        private readonly IStockLotRepository _stockLotRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public GetStockLotsNearExpiryQueryHandler(
            IStockLotRepository stockLotRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _stockLotRepository = stockLotRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<PagedResult<StockLotNearExpiryListItemResponse>>
            Handle(
                GetStockLotsNearExpiryQuery request,
                CancellationToken cancellationToken)
        {
            var today = _dateTimeProvider.Now.Date;

            var limitDate = today.AddDays(
                request.ExpiryDaysThreshold);

            IQueryable<StockLot> query = _stockLotRepository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Stock)
                    .ThenInclude(x => x.Product)
                .Where(x =>
                    x.AvailableQuantity > 0 &&
                    x.ExpiryDate.Date <= limitDate);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(x =>
                    EF.Functions.Like(x.Batch, $"%{term}%") ||
                    EF.Functions.Like(x.Brand, $"%{term}%") ||
                    EF.Functions.Like(x.Stock.Product.Name, $"%{term}%"));
            }

            var totalCount = await query
                .CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "expirydate" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.ExpiryDate)
                    : query.OrderBy(x => x.ExpiryDate),

                "productname" => request.SortOrder == "desc"
                    ? query.OrderByDescending(
                        x => x.Stock.Product.Name)
                    : query.OrderBy(
                        x => x.Stock.Product.Name),

                _ => query.OrderBy(x => x.ExpiryDate)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new StockLotNearExpiryListItemResponse(
                    x.Id,
                    x.Stock.ProductId,
                    x.Stock.Product.Name,
                    x.Batch,
                    x.Brand,
                    x.AvailableQuantity,
                    x.ExpiryDate,
                    (int)(x.ExpiryDate.Date - today).TotalDays,
                    x.CreatedOn,
                    x.UpdatedOn))
                .ToListAsync(cancellationToken);

            return PagedResult<StockLotNearExpiryListItemResponse>.Success(
                    items,
                    request.PageNumber,
                    request.PageSize,
                    totalCount,
                    "Lotes próximos ao vencimento listados com sucesso.");
        }
    }
}
