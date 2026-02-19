using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Requests;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockGeneralOverview
{
    public class GetStockGeneralOverviewQuery : PagedRequest, IRequest<PagedResponseO<StockOverviewDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
