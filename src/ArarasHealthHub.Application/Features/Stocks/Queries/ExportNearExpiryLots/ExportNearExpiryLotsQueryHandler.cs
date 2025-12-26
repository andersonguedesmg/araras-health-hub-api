using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Interfaces;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportNearExpiryLots
{
    public class ExportNearExpiryLotsQueryHandler : IRequestHandler<ExportNearExpiryLotsQuery, IEnumerable<StockLotNearExpiryDto>>
    {
        private readonly IStockLotRepository _stockLotRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        public ExportNearExpiryLotsQueryHandler(
            IStockLotRepository stockLotRepository,
            IDateTimeProvider dateTimeProvider,
            IMapper mapper)
        {
            _stockLotRepository = stockLotRepository;
            _dateTimeProvider = dateTimeProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockLotNearExpiryDto>> Handle(ExportNearExpiryLotsQuery request, CancellationToken cancellationToken)
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
                    sl.Stock.Product.Name.ToLower().Contains(searchTerm) ||
                    sl.Stock.Product.MainCategory!.Name.ToLower().Contains(searchTerm)
                );
            }

            var results = await lotQuery.OrderBy(sl => sl.ExpiryDate).ToListAsync(cancellationToken);

            return results.Select(sl => new StockLotNearExpiryDto
            {
                StockLotId = sl.Id,
                ProductId = sl.Stock.ProductId,
                Batch = sl.Batch,
                Brand = sl.Brand,
                AvailableQuantity = sl.AvailableQuantity,
                ExpiryDate = sl.ExpiryDate,
                DaysRemaining = (int)(sl.ExpiryDate.Date - today).TotalDays,
                Product = _mapper.Map<ProductDto>(sl.Stock.Product)
            });
        }
    }
}
