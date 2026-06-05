using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Orders.Approval;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder
{
    public class ApproveOrderCommandHandler : IRequestHandler<ApproveOrderCommand, Result<int>>
    {
        private readonly IOrderApprovalService _service;

        public ApproveOrderCommandHandler(
            IOrderApprovalService service)
        {
            _service = service;
        }

        public async Task<Result<int>> Handle(
            ApproveOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _service.ApproveOrderAsync(
                request,
                cancellationToken);
        }
    }
}
