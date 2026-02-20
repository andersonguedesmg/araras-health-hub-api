using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Exceptions;

using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/problem+json";

            ProblemDetails problem;

            if (exception is BaseAppException appException)
            {
                problem = new ProblemDetails
                {
                    Status = appException.StatusCode,
                    Title = GetTitle(appException.StatusCode),
                    Detail = appException.Message,
                    Type = $"https://httpstatuses.com/{appException.StatusCode}"
                };

                if (exception is ApplicationValidationException validation)
                {
                    problem.Extensions["errors"] = validation.Errors;
                }

                context.Response.StatusCode = appException.StatusCode;
            }
            else
            {
                problem = new ProblemDetails
                {
                    Status = 500,
                    Title = "Erro interno do servidor",
                    Detail = _env.IsDevelopment()
                        ? exception.ToString()
                        : "Ocorreu um erro inesperado.",
                    Type = "https://httpstatuses.com/500"
                };

                context.Response.StatusCode = 500;
            }

            var json = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(json);
        }

        private ProblemDetails CreateProblemDetails(
            HttpStatusCode status,
            string title,
            string detail,
            IDictionary<string, string[]>? errors = null)
        {
            var problem = new ProblemDetails
            {
                Status = (int)status,
                Title = title,
                Detail = detail,
                Type = $"https://httpstatuses.com/{(int)status}"
            };

            if (errors != null)
                problem.Extensions["errors"] = errors;

            return problem;
        }

        private static string GetTitle(int statusCode) => statusCode switch
        {
            400 => "Requisição inválida",
            401 => "Não autorizado",
            403 => "Acesso proibido",
            404 => "Recurso não encontrado",
            422 => "Regra de negócio violada",
            _ => "Erro"
        };
    }
}
