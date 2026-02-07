using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.DeactivatePresentationForm
{
    public class DeactivatePresentationFormCommandHandler : IRequestHandler<DeactivatePresentationFormCommand, ApiResponse<object>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public DeactivatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeactivatePresentationFormCommand request,
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

            if (!category.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyInactive(EntityNames.PresentationForm)
                );
            }

            category.Deactivate();
            await _presentationFormRepository.UpdateAsync(category, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityDeactivated(EntityNames.PresentationForm)
            );
        }
    }
}
