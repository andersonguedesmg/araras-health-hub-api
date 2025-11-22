using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStockOverview
{
    public class GetCriticalStockOverviewQueryHandler : IRequestHandler<GetCriticalStockOverviewQuery, PagedResponse<StockGeneralOverviewDto>>
    {
        private readonly IStockRepository _stockRepository;

        public GetCriticalStockOverviewQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<PagedResponse<StockGeneralOverviewDto>> Handle(GetCriticalStockOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetLowStockQueryable()
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
                case "currentquantity":
                    orderedStock = request.SortOrder?.ToLower() == "desc" ?
                        stockQuery.OrderByDescending(s => s.CurrentQuantity) :
                        stockQuery.OrderBy(s => s.CurrentQuantity);
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
                    Product = new ProductDto
                    {
                        Id = s.Product.Id,
                        Name = s.Product.Name,
                        Description = s.Product.Description,
                        MainCategory = s.Product.MainCategory,
                        SubCategory = s.Product.SubCategory,
                        PresentationForm = s.Product.PresentationForm,
                        IsActive = s.Product.IsActive
                    },
                    CurrentQuantity = s.CurrentQuantity,
                    ReservedQuantity = s.ReservedQuantity,
                    AvailableQuantity = s.AvailableQuantity,
                    MinQuantity = s.MinQuantity,
                    AverageCost = s.StockCost != null ? s.StockCost.AverageUnitCost : 0,
                    IsCritical = true
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
