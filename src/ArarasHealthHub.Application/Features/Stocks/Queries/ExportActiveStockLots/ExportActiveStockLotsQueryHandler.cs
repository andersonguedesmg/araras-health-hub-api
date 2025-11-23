using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportActiveStockLots
{
    public class ExportActiveStockLotsQueryHandler : IRequestHandler<ExportActiveStockLotsQuery, IEnumerable<ActiveStockLotDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;

        public ExportActiveStockLotsQueryHandler(IStockLotRepository stockLotRepository)
        {
            _stockLotRepository = stockLotRepository;
        }

        public async Task<IEnumerable<ActiveStockLotDto>> Handle(ExportActiveStockLotsQuery request, CancellationToken cancellationToken)
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

            var exportList = await lotQuery
                .OrderBy(sl => sl.Stock.Product.Name)
                .ThenBy(sl => sl.ExpiryDate)
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

            return exportList;
        }
    }
}
