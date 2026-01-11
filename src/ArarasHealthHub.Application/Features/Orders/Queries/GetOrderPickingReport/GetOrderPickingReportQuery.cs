using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingReport
{
    public class GetOrderPickingReportQuery : IRequest<ApiResponse<byte[]>>
    {
        public int OrderId { get; set; }
    }
}
