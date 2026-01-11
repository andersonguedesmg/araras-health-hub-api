using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Common
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
    public abstract class BaseApiController : ControllerBase
    {
        protected IMediator Mediator =>
            HttpContext.RequestServices.GetRequiredService<IMediator>();

        protected async Task<IActionResult> Send<TResponse>(IRequest<TResponse> request)
            where TResponse : ApiResponseBase
        {
            var response = await Mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }
    }
}
