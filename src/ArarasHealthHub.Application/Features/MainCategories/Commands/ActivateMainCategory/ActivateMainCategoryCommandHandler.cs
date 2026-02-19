using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.ActivateMainCategory
{
    public class ActivateMainCategoryCommandHandler : IRequestHandler<ActivateMainCategoryCommand, ApiResponse<object>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public ActivateMainCategoryCommandHandler(
            IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateMainCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _mainCategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.MainCategory)
                );
            }

            if (category.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.MainCategory)
                );
            }

            category.Activate();
            await _mainCategoryRepository.UpdateAsync(category, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.MainCategory)
            );
        }
    }
}
