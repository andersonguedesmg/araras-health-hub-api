using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByDirection
{
    public class GetMovementsByDirectionQuery : PagedRequest, IRequest<PagedResult<StockMovementListItemResponse>>
    {
        public MovementDirectionEnum Direction { get; set; }
    }
}
