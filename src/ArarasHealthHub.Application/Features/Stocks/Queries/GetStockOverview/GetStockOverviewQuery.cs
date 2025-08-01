using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockOverview
{
    public class GetStockOverviewQuery : PagedRequest, IRequest<PagedResponse<StockOverviewDto>> { }
}
