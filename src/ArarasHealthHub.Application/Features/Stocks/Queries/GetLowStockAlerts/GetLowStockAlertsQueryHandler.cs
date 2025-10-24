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
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetLowStockAlerts
{
    public class GetLowStockAlertsQueryHandler : IRequestHandler<GetLowStockAlertsQuery, PagedResponse<StockDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetLowStockAlertsQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockDto>> Handle(GetLowStockAlertsQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetLowStockQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                stockQuery = stockQuery.Where(s =>
                    s.Id.ToString().Contains(searchTermLower) ||
                    s.ProductId.ToString().Contains(searchTermLower) ||
                    s.MinQuantity.ToString().Contains(searchTermLower) ||
                    s.CurrentQuantity.ToString().Contains(searchTermLower) ||

                    (s.Product != null && (
                        s.Product.Name.ToLower().Contains(searchTermLower) ||
                        s.Product.Id.ToString().Contains(searchTermLower) ||
                        s.Product.MainCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.SubCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.PresentationForm.ToLower().Contains(searchTermLower) ||
                        s.Product.IsActive.ToString().ToLower().Contains(searchTermLower)
                    ))
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
                .ToListAsync(cancellationToken);

            var lowStockDtos = _mapper.Map<List<StockDto>>(pagedStocks);

            return new PagedResponse<StockDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                lowStockDtos
            );
        }
    }
}
