using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Middlewares
{
    public class AuthorizationErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized && !context.Response.HasStarted)
            {
                await context.Response.WriteAsJsonAsync(new ApiResponse<object>(StatusCodes.Status401Unauthorized, "Não autorizado", null!));
            }
        }
    }
}
