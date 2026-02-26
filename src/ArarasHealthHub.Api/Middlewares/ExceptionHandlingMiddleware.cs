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

            var problem = exception switch
            {
                ApplicationValidationException validation => CreateProblemDetails(
                    status: validation.StatusCode,
                    title: "Erro de validação",
                    detail: validation.Message,
                    errors: validation.Errors),

                BaseAppException appException => CreateProblemDetails(
                    status: appException.StatusCode,
                    title: GetTitle(appException.StatusCode),
                    detail: appException.Message),

                _ => CreateProblemDetails(
                    status: StatusCodes.Status500InternalServerError,
                    title: "Erro interno do servidor",
                    detail: _env.IsDevelopment()
                        ? exception.ToString()
                        : "Ocorreu um erro inesperado.")
            };

            problem.Extensions["traceId"] = context.TraceIdentifier;

            context.Response.StatusCode = problem.Status!.Value;

            await context.Response.WriteAsJsonAsync(problem);
        }

        private static ProblemDetails CreateProblemDetails(
            int status,
            string title,
            string detail,
            IReadOnlyDictionary<string, string[]>? errors = null)
        {
            var problem = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail,
                Type = $"https://httpstatuses.com/{status}"
            };

            if (errors is not null)
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
