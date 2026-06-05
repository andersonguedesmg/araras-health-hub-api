using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails
{
    public record GetOrderPickingDetailsQuery(int Id) : IRequest<Result<OrderPickingResponse>>;
}
