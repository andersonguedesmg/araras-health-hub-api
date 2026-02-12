using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetNearExpiryLots
{
    public class GetNearExpiryLotsQuery : PagedRequest, IRequest<PagedResponseO<StockLotNearExpiryDto>>
    {
        public string? SearchTerm { get; set; }
        public int ExpiryDaysThreshold { get; set; } = 90;
    }
}
