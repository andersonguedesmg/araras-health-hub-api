using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByDocument
{
    public class GetStockMovementsByDocumentQuery : PagedRequest, IRequest<PagedResult<StockMovementListItemResponse>>
    {
        public int SourceDocumentId { get; set; }

        public string SourceDocumentType { get; set; } = string.Empty;
    }
}
