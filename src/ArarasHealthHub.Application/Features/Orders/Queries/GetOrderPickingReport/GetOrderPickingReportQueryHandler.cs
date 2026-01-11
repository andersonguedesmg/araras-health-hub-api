using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingReport
{
    public class GetOrderPickingReportQueryHandler : IRequestHandler<GetOrderPickingReportQuery, ApiResponse<byte[]>>
    {
        private readonly IMediator _mediator;
        private readonly IPdfService _pdfService;

        public GetOrderPickingReportQueryHandler(IMediator mediator, IPdfService pdfService)
        {
            _mediator = mediator;
            _pdfService = pdfService;
        }

        public async Task<ApiResponse<byte[]>> Handle(GetOrderPickingReportQuery request, CancellationToken cancellationToken)
        {
            var orderResult = await _mediator.Send(new GetOrderPickingDetailsQuery { Id = request.OrderId }, cancellationToken);

            if (!orderResult.Success || orderResult.Data == null)
            {
                return new ApiResponse<byte[]>(orderResult.StatusCode, orderResult.Message, false);
            }

            byte[] pdfBuffer = await _pdfService.GeneratePickingListAsync(orderResult.Data);

            return new ApiResponse<byte[]>(StatusCodes.Status200OK, ApiMessages.PdfGeneratedSuccessfully, pdfBuffer);
        }
    }
}
