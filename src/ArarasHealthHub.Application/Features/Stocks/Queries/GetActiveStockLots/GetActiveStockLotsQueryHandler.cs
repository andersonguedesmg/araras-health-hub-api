using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetActiveStockLots
{
    public class GetActiveStockLotsQueryHandler : IRequestHandler<GetActiveStockLotsQuery, PagedResponse<ActiveStockLotDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;

        public GetActiveStockLotsQueryHandler(IStockLotRepository stockLotRepository)
        {
            _stockLotRepository = stockLotRepository;
        }

        public async Task<PagedResponse<ActiveStockLotDto>> Handle(GetActiveStockLotsQuery request, CancellationToken cancellationToken)
        {
            var lotQuery = _stockLotRepository.AsQueryable()
                .AsNoTracking()
                .Include(sl => sl.Stock)
                    .ThenInclude(s => s.Product)
                .Where(sl => sl.AvailableQuantity > 0)
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
                .Select(sl => new ActiveStockLotDto
                {
                    StockLotId = sl.Id,
                    ProductId = sl.Stock.ProductId,
                    Batch = sl.Batch,
                    Brand = sl.Brand,
                    AvailableQuantity = sl.AvailableQuantity,
                    ExpiryDate = sl.ExpiryDate,

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

            return new PagedResponse<ActiveStockLotDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                pagedLots
            );
        }
    }
}
