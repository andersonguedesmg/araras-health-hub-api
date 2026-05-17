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

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllMinimumStockLevels
{
    public class GetAllMinimumStockLevelsQueryHandler : IRequestHandler<GetAllMinimumStockLevelsQuery, PagedResult<MinimumStockLevelListItemResponse>>
    {
        private readonly IStockRepository _stockRepository;

        public GetAllMinimumStockLevelsQueryHandler(
            IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<PagedResult<MinimumStockLevelListItemResponse>> Handle(
            GetAllMinimumStockLevelsQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Stock> query = _stockRepository
                .AsQueryable()
                .AsNoTracking()
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

                "minimumstocklevel" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.MinQuantity)
                    : query.OrderBy(x => x.MinQuantity),

                "currentquantity" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.CurrentQuantity)
                    : query.OrderBy(x => x.CurrentQuantity),

                _ => query.OrderBy(x => x.Product.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new MinimumStockLevelListItemResponse(
                    x.Id,
                    x.ProductId,
                    x.Product.Name,
                    x.Product.MainCategory!.Name,
                    x.Product.SubCategory!.Name,
                    x.Product.PackagingType!.Name,
                    x.CurrentQuantity,
                    x.MinQuantity,
                    x.Product.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<MinimumStockLevelListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Níveis mínimos de estoque listados com sucesso.");
        }
    }
}
