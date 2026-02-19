using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockGeneralOverview;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockOverview
{
    public class GetStockGeneralOverviewQueryHandler : IRequestHandler<GetStockGeneralOverviewQuery, PagedResponseO<StockOverviewDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockGeneralOverviewQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseO<StockOverviewDto>> Handle(GetStockGeneralOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetQueryable()
                .AsNoTracking()
                .Include(s => s.StockCost)
                .Include(s => s.Product)
                    .ThenInclude(p => p.MainCategory)
                .Include(s => s.Product)
                    .ThenInclude(p => p.SubCategory)
                .Include(s => s.Product)
                    .ThenInclude(p => p.PresentationForm)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();

                stockQuery = stockQuery.Where(s =>
                    s.Product.Name.ToLower().Contains(searchTerm) ||
                    s.Product.Description.ToLower().Contains(searchTerm) ||
                    s.Product.MainCategory!.Name.ToLower().Contains(searchTerm) ||
                    s.Product.SubCategory!.Name.ToLower().Contains(searchTerm) ||
                    s.Product.PresentationForm!.Name.ToLower().Contains(searchTerm) ||
                    s.ProductId.ToString().Contains(searchTerm)
                );
            }

            var totalCount = await stockQuery.CountAsync(cancellationToken);

            IOrderedQueryable<Stock> orderedStock;

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
                case "availablequantity":
                    orderedStock = request.SortOrder?.ToLower() == "desc" ?
                        stockQuery.OrderByDescending(s => s.AvailableQuantity) :
                        stockQuery.OrderBy(s => s.AvailableQuantity);
                    break;
                default:
                    orderedStock = stockQuery.OrderBy(s => s.Product.Name);
                    break;
            }

            var pagedStocks = await orderedStock
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var stockDtos = pagedStocks.Select(s => new StockOverviewDto
            {
                Id = s.Id,
                ProductId = s.ProductId,
                Product = _mapper.Map<ProductDto>(s.Product),
                CurrentQuantity = s.CurrentQuantity,
                ReservedQuantity = s.ReservedQuantity,
                AvailableQuantity = s.AvailableQuantity,
                MinQuantity = s.MinQuantity,
                AverageCost = s.StockCost?.AverageUnitCost ?? 0,
                IsCritical = s.AvailableQuantity <= s.MinQuantity
            }).ToList();

            return new PagedResponseO<StockOverviewDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                stockDtos
            );
        }
    }
}
