using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.ActivatePresentationForm
{
    public class ActivatePresentationFormCommandHandler : IRequestHandler<ActivatePresentationFormCommand, ApiResponse<object>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public ActivatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _presentationFormRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.PresentationForm)
                );
            }

            if (category.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.PresentationForm)
                );
            }

            category.Activate();
            await _presentationFormRepository.UpdateAsync(category, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.PresentationForm)
            );
        }
    }
}
