using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAvailableStockLots
{
    public class GetAvailableStockLotsQuery : PagedRequest, IRequest<PagedResult<StockLotListItemResponse>> { }
}
