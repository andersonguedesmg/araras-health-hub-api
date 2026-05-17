using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingsBySupplier
{
    public class GetReceivingsBySupplierQuery : PagedRequest, IRequest<PagedResult<ReceivingListItemResponse>>
    {
        public int SupplierId { get; set; }
    }
}
