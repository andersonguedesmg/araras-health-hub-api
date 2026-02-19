using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory
{
    public class UpdateMainCategoryCommandHandler : IRequestHandler<UpdateMainCategoryCommand, ApiResponse<object>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public UpdateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            UpdateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _mainCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.MainCategory)
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

            var conflictExists = await _mainCategoryRepository
                .AsQueryable()
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
                    ApiMessages.EntityAlreadyExists(EntityNames.MainCategory)
                );
            }

            entity.Name = newName;
            entity.SetUpdatedOn();

            await _mainCategoryRepository.UpdateAsync(entity, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityUpdated(EntityNames.MainCategory)
            );
        }
    }
}
