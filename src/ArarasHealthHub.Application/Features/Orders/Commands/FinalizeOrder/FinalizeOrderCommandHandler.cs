using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Orders.Finalization;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder
{
    public class FinalizeOrderCommandHandler : IRequestHandler<FinalizeOrderCommand, Result<int>>
    {
        private readonly IOrderFinalizationService _service;

        public FinalizeOrderCommandHandler(
            IOrderFinalizationService service)
        {
            _service = service;
        }

        public async Task<Result<int>> Handle(
            FinalizeOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _service.FinalizeAsync(
                request,
                cancellationToken);
        }
    }
}
