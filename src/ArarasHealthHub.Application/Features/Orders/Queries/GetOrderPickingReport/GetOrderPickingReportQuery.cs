using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingReport
{
    public class GetOrderPickingReportQuery : IRequest<ApiResponseO<byte[]>>
    {
        public int OrderId { get; set; }
    }
}
