using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Orders.Creation;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IOrderCreationService _service;

        public CreateOrderCommandHandler(
            IOrderCreationService service)
        {
            _service = service;
        }

        public async Task<Result<int>> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _service.CreateOrderAsync(
                request,
                cancellationToken);
        }
    }
}
