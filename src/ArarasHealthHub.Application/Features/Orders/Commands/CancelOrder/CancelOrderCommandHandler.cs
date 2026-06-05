using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Orders.Cancellation;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Result<int>>
    {
        private readonly IOrderCancellationService _service;

        public CancelOrderCommandHandler(
            IOrderCancellationService service)
        {
            _service = service;
        }

        public async Task<Result<int>> Handle(
            CancelOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _service.CancelAsync(
                request,
                cancellationToken);
        }
    }
}
