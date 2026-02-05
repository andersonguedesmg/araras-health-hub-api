using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm
{
    public class UpdatePresentationFormCommandHandler : IRequestHandler<UpdatePresentationFormCommand, ApiResponse<object>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public UpdatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository,
            IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<object>> Handle(
            UpdatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _presentationFormRepository.GetByIdAsync(request.Id);

            if (entity is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.PresentationForm)
                );
            }

            var newName = request.Name.Trim();

            if (entity.Name.Equals(newName, StringComparison.OrdinalIgnoreCase))
            {
                return ApiResponse<object>.SuccessResponse(
                    StatusCodes.Status200OK,
                    ApiMessages.NoChangesDetected()
                );
            }

            var conflictExists = await _presentationFormRepository
                .GetQueryable()
                .AnyAsync(
                    c =>
                        c.Id != entity.Id &&
                        c.Name.ToLower() == newName.ToLower(),
                    cancellationToken
                );

            if (conflictExists)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyExists(EntityNames.PresentationForm)
                );
            }

            entity.Name = newName;
            entity.SetUpdatedOn();

            await _presentationFormRepository.UpdateAsync(entity);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityUpdated(EntityNames.PresentationForm)
            );
        }
    }
}
