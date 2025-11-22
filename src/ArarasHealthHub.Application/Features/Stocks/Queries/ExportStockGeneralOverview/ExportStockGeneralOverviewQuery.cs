using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportStockGeneralOverview
{
    public class ExportStockGeneralOverviewQuery : IRequest<IEnumerable<StockExportDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
