using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;

namespace ArarasHealthHub.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly bool _isDevelopment;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _isDevelopment = env.IsDevelopment();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

                if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound && !httpContext.Response.HasStarted)
                {
                    await HandleNotFoundAsync(httpContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorMessage = ApiMessages.MsgInternalServerError;
            var errorDetails = _isDevelopment ? exception.ToString() : null;

            var response = new ApiResponse<object>(
                StatusCodes.Status500InternalServerError,
                errorMessage,
                false
            );

            if (_isDevelopment && !string.IsNullOrEmpty(errorDetails))
            {
                response.Errors = new Dictionary<string, List<string>>
                {
                    { "StackTrace", new List<string> { errorDetails } }
                };
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            await context.Response.WriteAsync(jsonResponse);
        }

        private async Task HandleNotFoundAsync(HttpContext context)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var response = new ApiResponse<object>(
                StatusCodes.Status404NotFound,
                ApiMessages.MsgNotFound,
                false
            );

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
