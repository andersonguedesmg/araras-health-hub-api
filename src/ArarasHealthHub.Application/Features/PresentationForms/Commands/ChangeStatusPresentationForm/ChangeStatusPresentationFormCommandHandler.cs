using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.ChangeStatusPresentationForm
{
    public class ChangeStatusPresentationFormCommandHandler : IRequestHandler<ChangeStatusPresentationFormCommand, ApiResponse<object>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public ChangeStatusPresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ChangeStatusPresentationFormCommand command,
            CancellationToken cancellationToken)
        {
            var existingPresentationForm =
                await _presentationFormRepository.GetByIdAsync(command.Id);

            if (existingPresentationForm is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Forma de apresentação")
                );
            }

            if (command.IsActive)
            {
                existingPresentationForm.Activate();
            }
            else
            {
                existingPresentationForm.Deactivate();
            }

            await _presentationFormRepository.UpdateAsync(existingPresentationForm);

            var message = command.IsActive
                ? ApiMessages.ActivatedSuccessfully("Forma de apresentação")
                : ApiMessages.DeactivatedSuccessfully("Forma de apresentação");

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                message
            );
        }
    }
}
