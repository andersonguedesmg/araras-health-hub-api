using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Orders.Separation;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder
{
    public class SeparateOrderCommandHandler : IRequestHandler<SeparateOrderCommand, Result<int>>
    {
        private readonly IOrderSeparationService _service;

        public SeparateOrderCommandHandler(
            IOrderSeparationService service)
        {
            _service = service;
        }

        public async Task<Result<int>> Handle(
            SeparateOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _service.SeparateAsync(
                request,
                cancellationToken);
        }
    }
}
