using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockOverview
{
    public class GetStockOverviewQueryHandler : IRequestHandler<GetStockOverviewQuery, PagedResponse<StockOverviewDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockOverviewQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockOverviewDto>> Handle(GetStockOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetQueryable().Include(s => s.Product).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                stockQuery = stockQuery.Where(s =>
                    s.Id.ToString().Contains(searchTermLower) ||
                    s.ProductId.ToString().Contains(searchTermLower) ||
                    s.MinQuantity.ToString().Contains(searchTermLower) ||

                    (s.Product != null && (
                        s.Product.Name.ToLower().Contains(searchTermLower) ||
                        s.Product.Id.ToString().Contains(searchTermLower) ||
                        s.Product.Description.ToLower().Contains(searchTermLower) ||
                        s.Product.MainCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.SubCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.PresentationForm.ToLower().Contains(searchTermLower) ||
                        s.Product.IsActive.ToString().ToLower().Contains(searchTermLower)
                    ))
                );
            }

            var totalCount = await _stockRepository.GetTotalCountAsync();

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
                .ToListAsync(cancellationToken);

            var stockOverviewDtos = _mapper.Map<List<StockOverviewDto>>(pagedStocks);

            return new PagedResponse<StockOverviewDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                stockOverviewDtos
            );
        }
    }
}
