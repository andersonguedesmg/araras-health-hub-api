using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetLowStockAlerts
{
    public class GetLowStockAlertsQuery : PagedRequest, IRequest<PagedResponse<StockDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
