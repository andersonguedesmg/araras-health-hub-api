using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportStockGeneralOverview
{
    public class ExportStockGeneralOverviewQueryHandler : IRequestHandler<ExportStockGeneralOverviewQuery, IEnumerable<StockExportDto>>
    {
        private readonly IStockRepository _stockRepository;

        public ExportStockGeneralOverviewQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockExportDto>> Handle(ExportStockGeneralOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetQueryable()
                .AsNoTracking()
                .Include(s => s.StockCost)
                .Include(s => s.Product)
                    .ThenInclude(p => p.MainCategory)
                .Include(s => s.Product)
                    .ThenInclude(p => p.SubCategory)
                .Include(s => s.Product)
                    .ThenInclude(p => p.PackagingType)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();

                stockQuery = stockQuery.Where(s =>
                    s.Product.Name.ToLower().Contains(searchTerm) ||
                    s.Product.Description.ToLower().Contains(searchTerm) ||
                    s.Product.MainCategory!.Name.ToLower().Contains(searchTerm) ||
                    s.Product.SubCategory!.Name.ToLower().Contains(searchTerm) ||
                    s.Product.PackagingType!.Name.ToLower().Contains(searchTerm) ||
                    s.ProductId.ToString().Contains(searchTerm)
                );
            }

            var exportList = await stockQuery
                .Select(s => new StockExportDto
                {
                    ProductId = s.ProductId,
                    ProductName = s.Product.Name,
                    MainCategory = s.Product.MainCategory != null ? s.Product.MainCategory.Name : string.Empty,
                    SubCategory = s.Product.SubCategory != null ? s.Product.SubCategory.Name : string.Empty,
                    PackagingType = s.Product.PackagingType != null ? s.Product.PackagingType.Name : string.Empty,
                    CurrentQuantity = s.CurrentQuantity,
                    ReservedQuantity = s.ReservedQuantity,
                    AvailableQuantity = s.AvailableQuantity,
                    MinQuantity = s.MinQuantity,
                    AverageCost = s.StockCost != null ? s.StockCost.AverageUnitCost : 0,
                    IsCritical = s.AvailableQuantity <= s.MinQuantity,
                    CriticalStatus = s.AvailableQuantity <= s.MinQuantity ? "Sim" : "Não",
                    CreatedOn = s.CreatedOn,
                    UpdatedOn = s.UpdatedOn,
                })
                .OrderBy(d => d.ProductName)
                .ToListAsync(cancellationToken);

            return exportList;
        }
    }
}
