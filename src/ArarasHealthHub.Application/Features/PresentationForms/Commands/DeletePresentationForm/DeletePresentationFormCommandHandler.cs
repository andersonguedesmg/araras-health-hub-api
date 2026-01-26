using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.DeletePresentationForm
{
    public class DeletePresentationFormCommandHandler : IRequestHandler<DeletePresentationFormCommand, ApiResponse<object>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public DeletePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeletePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var existingPresentationForm =
                await _presentationFormRepository.GetByIdAsync(request.Id);

            if (existingPresentationForm is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Forma de apresentação")
                );
            }

            await _presentationFormRepository.DeleteAsync(existingPresentationForm);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Forma de apresentação")
            );
        }
    }
}
