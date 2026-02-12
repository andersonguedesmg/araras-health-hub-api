using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments
{
    public class GetAllStockAdjustmentsQuery : PagedRequest, IRequest<PagedResponseO<StockAdjustmentDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
