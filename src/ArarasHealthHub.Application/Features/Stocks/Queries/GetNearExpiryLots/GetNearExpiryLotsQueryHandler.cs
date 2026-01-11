using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Interfaces;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetNearExpiryLots
{
    public class GetNearExpiryLotsQueryHandler : IRequestHandler<GetNearExpiryLotsQuery, PagedResponse<StockLotNearExpiryDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        public GetNearExpiryLotsQueryHandler(
            IStockLotRepository stockLotRepository,
            IDateTimeProvider dateTimeProvider,
            IMapper mapper)
        {
            _stockLotRepository = stockLotRepository;
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
        }

        public async Task<PagedResponse<StockLotNearExpiryDto>> Handle(GetNearExpiryLotsQuery request, CancellationToken cancellationToken)
        {
            var today = _dateTimeProvider.Now.Date;
            var expiryLimitDate = today.AddDays(request.ExpiryDaysThreshold);

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
                        .ThenInclude(p => p.PresentationForm)
                .Where(sl => sl.AvailableQuantity > 0 && sl.ExpiryDate.Date <= expiryLimitDate)
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
                    sl.Stock.Product.PresentationForm!.Name.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await lotQuery.CountAsync(cancellationToken);

            IOrderedQueryable<StockLot> orderedLots;

            switch (request.OrderBy?.ToLower())
            {
                case "expirydate":
                    orderedLots = request.SortOrder?.ToLower() == "desc" ?
                        lotQuery.OrderByDescending(sl => sl.ExpiryDate) :
                        lotQuery.OrderBy(sl => sl.ExpiryDate);
                    break;
                case "productname":
                    orderedLots = request.SortOrder?.ToLower() == "desc" ?
                        lotQuery.OrderByDescending(sl => sl.Stock.Product.Name) :
                        lotQuery.OrderBy(sl => sl.Stock.Product.Name);
                    break;
                default:
                    orderedLots = request.SortOrder?.ToLower() == "desc" ?
                        lotQuery.OrderByDescending(sl => sl.ExpiryDate) :
                        lotQuery.OrderBy(sl => sl.ExpiryDate);
                    break;
            }

            var pagedLots = await orderedLots
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var dtos = pagedLots.Select(sl => new StockLotNearExpiryDto
            {
                StockLotId = sl.Id,
                ProductId = sl.Stock.ProductId,
                Batch = sl.Batch,
                Brand = sl.Brand,
                AvailableQuantity = sl.AvailableQuantity,
                ExpiryDate = sl.ExpiryDate,
                DaysRemaining = (int)(sl.ExpiryDate.Date - today).TotalDays,
                Product = _mapper.Map<ProductDto>(sl.Stock.Product)
            }).ToList();

            return new PagedResponse<StockLotNearExpiryDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtos
            );
        }
    }
}
