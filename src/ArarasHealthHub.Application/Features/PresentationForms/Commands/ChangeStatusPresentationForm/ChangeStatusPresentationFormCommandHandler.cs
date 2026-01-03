using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.ChangeStatusPresentationForm
{
    public class ChangeStatusPresentationFormCommandHandler : IRequestHandler<ChangeStatusPresentationFormCommand, ApiResponse<bool>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public ChangeStatusPresentationFormCommandHandler(IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusPresentationFormCommand command, CancellationToken cancellationToken)
        {
            var existingPresentationForm = await _presentationFormRepository.GetByIdAsync(command.Id);

            if (existingPresentationForm == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Forma de Apresentação"), false);
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

            var message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Forma de Apresentação") : ApiMessages.DeactivatedSuccessfully("Forma de Apresentação");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
