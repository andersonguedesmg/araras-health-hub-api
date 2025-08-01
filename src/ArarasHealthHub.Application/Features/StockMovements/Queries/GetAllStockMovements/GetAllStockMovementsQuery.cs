using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements
{
    public record GetAllStockMovementsQuery(
        int PageNumber,
        int PageSize,
        string OrderBy,
        string SortOrder
    ) : IRequest<PagedResponse<StockMovementDto>>;
}
