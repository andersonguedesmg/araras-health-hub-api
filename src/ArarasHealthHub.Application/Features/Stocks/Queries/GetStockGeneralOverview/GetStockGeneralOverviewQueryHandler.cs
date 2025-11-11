using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockGeneralOverview;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockOverview
{
    public class GetStockGeneralOverviewQueryHandler : IRequestHandler<GetStockGeneralOverviewQuery, PagedResponse<StockGeneralOverviewDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockGeneralOverviewQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockGeneralOverviewDto>> Handle(GetStockGeneralOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetQueryable()
                            .AsNoTracking()
                            .Include(s => s.Product)
                            .Include(s => s.StockCost)
                            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                stockQuery = stockQuery.Where(s =>
                    s.Product != null && (
                        s.Product.Name.ToLower().Contains(searchTermLower) ||
                        s.Product.Description.ToLower().Contains(searchTermLower) ||
                        s.Product.MainCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.SubCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.PresentationForm.ToLower().Contains(searchTermLower)
                    ) ||
                    s.ProductId.ToString().Contains(searchTermLower)
                );
            }

            var totalCount = await stockQuery.CountAsync(cancellationToken);

            IQueryable<Stock> orderedStock;

            switch (request.OrderBy?.ToLower())
            {
                case "productname":
                    orderedStock = request.SortOrder?.ToLower() == "desc" ?
                        stockQuery.OrderByDescending(s => s.Product.Name) :
                        stockQuery.OrderBy(s => s.Product.Name);
                    break;
                case "minquantity":
                    orderedStock = request.SortOrder?.ToLower() == "desc" ?
                        stockQuery.OrderByDescending(s => s.MinQuantity) :
                        stockQuery.OrderBy(s => s.MinQuantity);
                    break;
                default:
                    orderedStock = request.SortOrder?.ToLower() == "desc" ?
                        stockQuery.OrderByDescending(s => s.Product.Name) :
                        stockQuery.OrderBy(s => s.Product.Name);
                    break;
            }

            var pagedStocks = await orderedStock
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(s => new StockGeneralOverviewDto
                {
                    Id = s.Id,
                    ProductId = s.ProductId,
                    Product = _mapper.Map<ProductDto>(s.Product),
                    CurrentQuantity = s.CurrentQuantity,
                    ReservedQuantity = s.ReservedQuantity,
                    AvailableQuantity = s.AvailableQuantity,
                    MinQuantity = s.MinQuantity,
                    AverageCost = s.StockCost != null ? s.StockCost.AverageUnitCost : 0,
                    IsCritical = s.AvailableQuantity <= s.MinQuantity
                })
                .ToListAsync(cancellationToken);

            return new PagedResponse<StockGeneralOverviewDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                pagedStocks
            );
        }
    }
}
