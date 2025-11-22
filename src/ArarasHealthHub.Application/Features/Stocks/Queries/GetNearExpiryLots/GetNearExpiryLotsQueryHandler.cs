using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Interfaces;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetNearExpiryLots
{
    public class GetNearExpiryLotsQueryHandler : IRequestHandler<GetNearExpiryLotsQuery, PagedResponse<StockLotNearExpiryDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public GetNearExpiryLotsQueryHandler(IStockLotRepository stockLotRepository, IDateTimeProvider dateTimeProvider)
        {
            _stockLotRepository = stockLotRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<PagedResponse<StockLotNearExpiryDto>> Handle(GetNearExpiryLotsQuery request, CancellationToken cancellationToken)
        {
            var today = _dateTimeProvider.Now.Date;
            var expiryLimitDate = today.AddDays(request.ExpiryDaysThreshold);

            var lotQuery = _stockLotRepository.AsQueryable()
                .AsNoTracking()
                .Include(sl => sl.Stock)
                    .ThenInclude(s => s.Product)
                .Where(sl => sl.AvailableQuantity > 0 && sl.ExpiryDate.Date <= expiryLimitDate)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                lotQuery = lotQuery.Where(sl =>
                    sl.Batch.ToLower().Contains(searchTermLower) ||
                    sl.Brand.ToLower().Contains(searchTermLower) ||
                    sl.Stock.Product.Name.ToLower().Contains(searchTermLower) ||
                    sl.Stock.Product.Description.ToLower().Contains(searchTermLower)
                );
            }

            var totalCount = await lotQuery.CountAsync(cancellationToken);

            IQueryable<StockLot> orderedLots;

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
                .Select(sl => new StockLotNearExpiryDto
                {
                    StockLotId = sl.Id,
                    ProductId = sl.Stock.ProductId,
                    Batch = sl.Batch,
                    Brand = sl.Brand,
                    AvailableQuantity = sl.AvailableQuantity,
                    ExpiryDate = sl.ExpiryDate,
                    DaysRemaining = (int)(sl.ExpiryDate.Date - today).TotalDays,

                    Product = new ProductDto
                    {
                        Id = sl.Stock.Product.Id,
                        Name = sl.Stock.Product.Name,
                        Description = sl.Stock.Product.Description,
                        MainCategory = sl.Stock.Product.MainCategory,
                        SubCategory = sl.Stock.Product.SubCategory,
                        PresentationForm = sl.Stock.Product.PresentationForm,
                        IsActive = sl.Stock.Product.IsActive
                    }
                })
                .ToListAsync(cancellationToken);

            return new PagedResponse<StockLotNearExpiryDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                pagedLots
            );
        }
    }
}
