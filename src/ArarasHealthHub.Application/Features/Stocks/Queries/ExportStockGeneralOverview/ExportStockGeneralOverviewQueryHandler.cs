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
    public class ExportStockGeneralOverviewQueryHandler : IRequestHandler<ExportStockGeneralOverviewQuery, IEnumerable<StockGeneralExportDto>>
    {
        private readonly IStockRepository _stockRepository;

        public ExportStockGeneralOverviewQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockGeneralExportDto>> Handle(ExportStockGeneralOverviewQuery request, CancellationToken cancellationToken)
        {
            var stockQuery = _stockRepository.GetQueryable()
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
