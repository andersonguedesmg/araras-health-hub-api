using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Orders.Return;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder
{
    public class CreateReturnOrderCommandHandler : IRequestHandler<CreateReturnOrderCommand, Result<int>>
    {
        private readonly IOrderReturnService _service;

        public CreateReturnOrderCommandHandler(
            IOrderReturnService service)
        {
            _service = service;
        }

        public async Task<Result<int>> Handle(
            CreateReturnOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(
                request,
                cancellationToken);
        }
    }
}
