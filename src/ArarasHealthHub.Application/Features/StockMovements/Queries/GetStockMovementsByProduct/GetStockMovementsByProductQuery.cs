using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByProduct
{
    public class GetStockMovementsByProductQuery : PagedRequest, IRequest<PagedResult<StockMovementListItemResponse>>
    {
        public int ProductId { get; set; }
    }
}
