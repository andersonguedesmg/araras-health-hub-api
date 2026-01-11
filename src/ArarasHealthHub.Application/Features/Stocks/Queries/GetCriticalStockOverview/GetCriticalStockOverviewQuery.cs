using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStockOverview
{
    public class GetCriticalStockOverviewQuery : PagedRequest, IRequest<PagedResponse<StockOverviewDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
