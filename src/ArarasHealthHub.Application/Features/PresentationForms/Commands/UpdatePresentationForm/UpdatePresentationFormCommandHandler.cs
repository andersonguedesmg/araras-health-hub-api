using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm
{
    public class UpdatePresentationFormCommandHandler : IRequestHandler<UpdatePresentationFormCommand, ApiResponse<bool>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public UpdatePresentationFormCommandHandler(IPresentationFormRepository presentationFormRepository, IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdatePresentationFormCommand request, CancellationToken cancellationToken)
        {
            var existingPresentationForm = await _presentationFormRepository.GetByIdAsync(request.Id);

            if (existingPresentationForm == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Forma de Apresentação"), false);
            }

            _mapper.Map(request, existingPresentationForm);

            existingPresentationForm.SetUpdatedOn();

            await _presentationFormRepository.UpdateAsync(existingPresentationForm);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.UpdatedSuccessfully("Forma de Apresentação"), true);
        }
    }
}
