using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.ExportNearExpiryLots
{
    public class ExportNearExpiryLotsQuery : IRequest<IEnumerable<StockLotNearExpiryDto>>
    {
        public string? SearchTerm { get; set; }
        public int ExpiryDaysThreshold { get; set; } = 90;
    }
}
