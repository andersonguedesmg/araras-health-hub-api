using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings
{
    public class GetAllReceivingsQuery : PagedRequest, IRequest<PagedResult<ReceivingListItemResponse>> { }
}
