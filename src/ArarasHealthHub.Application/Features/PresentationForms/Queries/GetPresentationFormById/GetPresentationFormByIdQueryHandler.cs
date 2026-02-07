using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormById
{
    public class GetPresentationFormByIdQueryHandler : IRequestHandler<GetPresentationFormByIdQuery, ApiResponse<PresentationFormDto>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public GetPresentationFormByIdQueryHandler(
            IPresentationFormRepository presentationFormRepository,
            IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PresentationFormDto>> Handle(
            GetPresentationFormByIdQuery request,
            CancellationToken cancellationToken)
        {
            var presentationForm = await _presentationFormRepository.GetByIdAsync(request.Id, cancellationToken);

            if (presentationForm is null)
            {
                return ApiResponse<PresentationFormDto>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.PresentationForm)
                );
            }

            var presentationFormDto = _mapper.Map<PresentationFormDto>(presentationForm);

            return ApiResponse<PresentationFormDto>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                presentationFormDto
            );
        }
    }
}
