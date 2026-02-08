using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm
{
    public class CreatePresentationFormCommandHandler : IRequestHandler<CreatePresentationFormCommand, ApiResponse<int>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public CreatePresentationFormCommandHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<ApiResponse<int>> Handle(
            CreatePresentationFormCommand request,
            CancellationToken cancellationToken)
        {
            var name = request.Name.Trim();

            var alreadyExists = await _presentationFormRepository
                .AsQueryable()
                .AnyAsync(
                    c => c.Name.ToLower() == name.ToLower(),
                    cancellationToken
                );

            if (alreadyExists)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyExists(EntityNames.PresentationForm)
                );
            }

            var entity = new PresentationForm
            {
                Name = name
            };

            await _presentationFormRepository.AddAsync(entity, cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.PresentationForm),
                entity.Id
            );
        }
    }
}
