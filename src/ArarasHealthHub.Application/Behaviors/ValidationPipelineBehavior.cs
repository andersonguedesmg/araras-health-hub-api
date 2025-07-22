using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApiResponseBase, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var validationContext = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
            {
                var errors = new Dictionary<string, List<string>>();
                foreach (var failure in failures)
                {
                    if (!errors.ContainsKey(failure.PropertyName))
                    {
                        errors[failure.PropertyName] = new List<string>();
                    }
                    errors[failure.PropertyName].Add(failure.ErrorMessage);
                }

                var response = new TResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ApiMessages.MsgValidationErrors,
                    Errors = errors,
                    Success = false
                };

                return response;
            }

            return await next();
        }
    }
}
