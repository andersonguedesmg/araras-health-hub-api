using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportActiveStockLots
{
    public class ExportActiveStockLotsQueryHandler : IRequestHandler<ExportActiveStockLotsQuery, IEnumerable<ActiveStockLotDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;
        private readonly IMapper _mapper;

        public ExportActiveStockLotsQueryHandler(IStockLotRepository stockLotRepository, IMapper mapper)
        {
            _stockLotRepository = stockLotRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActiveStockLotDto>> Handle(ExportActiveStockLotsQuery request, CancellationToken cancellationToken)
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
                    sl.Stock.Product.Name.ToLower().Contains(searchTerm) ||
                    sl.Stock.Product.MainCategory!.Name.ToLower().Contains(searchTerm)
                );
            }

            var results = await lotQuery
                .OrderBy(sl => sl.Stock.Product.Name)
                .ThenBy(sl => sl.ExpiryDate)
                .ToListAsync(cancellationToken);

            return results.Select(sl => new ActiveStockLotDto
            {
                StockLotId = sl.Id,
                ProductId = sl.Stock.ProductId,
                Batch = sl.Batch,
                Brand = sl.Brand,
                AvailableQuantity = sl.AvailableQuantity,
                ExpiryDate = sl.ExpiryDate,
                Product = _mapper.Map<ProductDto>(sl.Stock.Product)
            });
        }
    }
}
