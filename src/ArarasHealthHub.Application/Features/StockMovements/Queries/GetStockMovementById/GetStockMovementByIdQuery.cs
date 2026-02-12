using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById
{
    public record GetStockMovementByIdQuery(int Id) : IRequest<ApiResponseO<StockMovementDto>>;
}
