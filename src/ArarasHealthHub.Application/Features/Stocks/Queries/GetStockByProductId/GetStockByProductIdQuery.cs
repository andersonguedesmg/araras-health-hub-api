using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Queries.GetStockByProductId
{
    public record GetStockByProductIdQuery(int ProductId) : IRequest<ApiResponse<StockDto>>;
}
