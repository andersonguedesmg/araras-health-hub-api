using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm
{
    public class CreatePresentationFormCommandHandler : IRequestHandler<CreatePresentationFormCommand, ApiResponse<int>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public CreatePresentationFormCommandHandler(IPresentationFormRepository presentationFormRepository, IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreatePresentationFormCommand request, CancellationToken cancellationToken)
        {
            var existingPresentationForm = await _presentationFormRepository.GetByPresentationFormNameAsync(request.Name);
            if (existingPresentationForm != null)
            {
                return new ApiResponse<int>(StatusCodes.Status409Conflict, ApiMessages.MainCategoryAlreadyExists, 0);
            }

            var mainCategory = _mapper.Map<PresentationForm>(request);

            await _presentationFormRepository.AddAsync(mainCategory);

            return new ApiResponse<int>(StatusCodes.Status201Created, ApiMessages.CreatedSuccessfully("Forma de Apresentação"), mainCategory.Id);
        }
    }
}
