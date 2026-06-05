using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Middlewares
{
    public class AuthenticationProblemDetailsMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationProblemDetailsMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            await _next(context);

            if (context.Response.HasStarted)
                return;

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                await WriteProblemAsync(
                    context,
                    401,
                    "Não autorizado",
                    "Autenticação necessária.");
            }

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await WriteProblemAsync(
                    context,
                    403,
                    "Acesso proibido",
                    "Permissões insuficientes.");
            }
        }

        private static async Task WriteProblemAsync(
            HttpContext context,
            int status,
            string title,
            string detail)
        {
            context.Response.ContentType = "application/problem+json";

            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail,
                Type = $"https://httpstatuses.com/{status}"
            };

            problem.Extensions["traceId"] =
                context.TraceIdentifier;

            await context.Response.WriteAsJsonAsync(
                problem);
        }
    }
}
