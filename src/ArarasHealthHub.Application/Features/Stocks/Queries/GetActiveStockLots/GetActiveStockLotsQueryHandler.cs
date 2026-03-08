using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetActiveStockLots
{
    public class GetActiveStockLotsQueryHandler : IRequestHandler<GetActiveStockLotsQuery, PagedResponseO<ActiveStockLotDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;
        private readonly IMapper _mapper;

        public GetActiveStockLotsQueryHandler(IStockLotRepository stockLotRepository, IMapper mapper)
        {
            _stockLotRepository = stockLotRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseO<ActiveStockLotDto>> Handle(GetActiveStockLotsQuery request, CancellationToken cancellationToken)
        {
            var lotQuery = _stockLotRepository.AsQueryable()
                .AsNoTracking()
                .Include(sl => sl.Stock)
                    .ThenInclude(s => s.Product)
                        .ThenInclude(p => p.MainCategory)
                .Include(sl => sl.Stock)
                    .ThenInclude(s => s.Product)
                        .ThenInclude(p => p.SubCategory)
                .Include(sl => sl.Stock)
                    .ThenInclude(s => s.Product)
                        .ThenInclude(p => p.PackagingType)
                .Where(sl => sl.AvailableQuantity > 0)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();

                lotQuery = lotQuery.Where(sl =>
                    sl.Batch.ToLower().Contains(searchTerm) ||
                    sl.Brand.ToLower().Contains(searchTerm) ||
                    sl.Stock.Product.Name.ToLower().Contains(searchTerm) ||
                    sl.Stock.Product.MainCategory!.Name.ToLower().Contains(searchTerm) ||
                    sl.Stock.Product.SubCategory!.Name.ToLower().Contains(searchTerm) ||
                    sl.Stock.Product.PackagingType!.Name.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await lotQuery.CountAsync(cancellationToken);

            IQueryable<StockLot> orderedLots;
            var isDesc = request.SortOrder?.ToLower() == "desc";

            switch (request.OrderBy?.ToLower())
            {
                case "expirydate":
                    orderedLots = isDesc ? lotQuery.OrderByDescending(sl => sl.ExpiryDate) : lotQuery.OrderBy(sl => sl.ExpiryDate);
                    break;
                case "productname":
                    orderedLots = isDesc ? lotQuery.OrderByDescending(sl => sl.Stock.Product.Name) : lotQuery.OrderBy(sl => sl.Stock.Product.Name);
                    break;
                default:
                    orderedLots = lotQuery.OrderBy(sl => sl.Stock.Product.Name).ThenBy(sl => sl.ExpiryDate);
                    break;
            }

            var pagedLots = await orderedLots
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var dtos = pagedLots.Select(sl => new ActiveStockLotDto
            {
                StockLotId = sl.Id,
                ProductId = sl.Stock.ProductId,
                Batch = sl.Batch,
                Brand = sl.Brand,
                AvailableQuantity = sl.AvailableQuantity,
                ExpiryDate = sl.ExpiryDate,
                Product = _mapper.Map<ProductDto>(sl.Stock.Product)
            }).ToList();

            return new PagedResponseO<ActiveStockLotDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtos
            );
        }
    }
}
