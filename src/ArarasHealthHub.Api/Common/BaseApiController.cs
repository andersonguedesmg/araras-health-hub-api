using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Common
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseApiController : ControllerBase
    {
        protected IMediator Mediator =>
            HttpContext.RequestServices.GetRequiredService<IMediator>();

        protected async Task<IActionResult> Send<TResponse>(
            IRequest<TResponse> request,
            CancellationToken cancellationToken)
            where TResponse : Result
        {
            var result = await Mediator.Send(request, cancellationToken);

            return result switch
            {
                Result r when r.GetType() == typeof(Result)
                    => Ok(new
                    {
                        message = r.Message
                    }),

                _ => Ok(result)
            };
        }
    }
}
