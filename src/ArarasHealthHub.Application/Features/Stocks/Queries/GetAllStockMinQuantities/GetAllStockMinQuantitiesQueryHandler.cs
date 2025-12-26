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

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockMinQuantities
{
    public class GetAllStockMinQuantitiesQueryHandler : IRequestHandler<GetAllStockMinQuantitiesQuery, PagedResponse<StockMinQuantityDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetAllStockMinQuantitiesQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockMinQuantityDto>> Handle(GetAllStockMinQuantitiesQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetQueryable()
                .AsNoTracking()
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
                    s.Product.MainCategory!.Name.ToLower().Contains(searchTerm) ||
                    s.Product.SubCategory!.Name.ToLower().Contains(searchTerm) ||
                    s.Product.PresentationForm!.Name.ToLower().Contains(searchTerm) ||
                    s.MinQuantity.ToString().Contains(searchTerm)
                );
            }

            var totalCount = await stockQuery.CountAsync(cancellationToken);

            IQueryable<Stock> orderedStock;
            var isDesc = request.SortOrder?.ToLower() == "desc";

            switch (request.OrderBy?.ToLower())
            {
                case "productname":
                    orderedStock = isDesc
                        ? stockQuery.OrderByDescending(s => s.Product.Name)
                        : stockQuery.OrderBy(s => s.Product.Name);
                    break;
                case "minquantity":
                    orderedStock = isDesc
                        ? stockQuery.OrderByDescending(s => s.MinQuantity)
                        : stockQuery.OrderBy(s => s.MinQuantity);
                    break;
                default:
                    orderedStock = stockQuery.OrderBy(s => s.Product.Name);
                    break;
            }

            var pagedStocks = await orderedStock
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var dtos = _mapper.Map<List<StockMinQuantityDto>>(pagedStocks);

            return new PagedResponse<StockMinQuantityDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtos
            );
        }
    }
}
