using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByReason
{
    public class GetMovementsByReasonQuery : PagedRequest, IRequest<PagedResult<StockMovementListItemResponse>>
    {
        public MovementReasonEnum Reason { get; set; }
    }
}
