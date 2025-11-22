using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportCriticalStockOverview
{
    public class ExportCriticalStockOverviewQueryHandler : IRequestHandler<ExportCriticalStockOverviewQuery, IEnumerable<StockGeneralExportDto>>
    {
        private readonly IStockRepository _stockRepository;

        public ExportCriticalStockOverviewQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockGeneralExportDto>> Handle(ExportCriticalStockOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetLowStockQueryable()
                .AsNoTracking()
                .Include(s => s.Product)
                .Include(s => s.StockCost)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                stockQuery = stockQuery.Where(s =>
                    s.Product != null && (
                        s.Product.Name.ToLower().Contains(searchTermLower) ||
                        s.Product.Description.ToLower().Contains(searchTermLower) ||
                        s.Product.MainCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.SubCategory.ToLower().Contains(searchTermLower) ||
                        s.Product.PresentationForm.ToLower().Contains(searchTermLower)
                    ) ||
                    s.ProductId.ToString().Contains(searchTermLower)
                );
            }

            var exportList = await stockQuery
                .OrderBy(s => s.Product.Name)
                .Select(s => new StockGeneralExportDto
                {
                    ProductId = s.ProductId,
                    ProductName = s.Product.Name,
                    MainCategory = s.Product.MainCategory,
                    SubCategory = s.Product.SubCategory,
                    PresentationForm = s.Product.PresentationForm,
                    CurrentQuantity = s.CurrentQuantity,
                    ReservedQuantity = s.ReservedQuantity,
                    AvailableQuantity = s.AvailableQuantity,
                    MinQuantity = s.MinQuantity,
                    AverageCost = s.StockCost != null ? s.StockCost.AverageUnitCost : 0,
                    IsCritical = true,
                    CriticalStatus = "Sim",
                    CreatedOn = s.CreatedOn,
                    UpdatedOn = s.UpdatedOn,
                })
                .ToListAsync(cancellationToken);

            return exportList;
        }
    }
}
