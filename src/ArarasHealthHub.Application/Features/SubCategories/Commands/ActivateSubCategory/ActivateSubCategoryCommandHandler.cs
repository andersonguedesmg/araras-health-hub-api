using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory
{
    public class ActivateSubCategoryCommandHandler : IRequestHandler<ActivateSubCategoryCommand, ApiResponse<object>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public ActivateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository,
            IMainCategoryRepository mainCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateSubCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryRepository
                .GetByIdAsync(command.Id);

            if (subCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.SubCategory)
                );
            }

            if (subCategory.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.SubCategory)
                );
            }

            var mainCategory = await _mainCategoryRepository
                .GetByIdAsync(subCategory.MainCategoryId);

            if (mainCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.MainCategory)
                );
            }

            if (!mainCategory.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.CannotActivateBecauseInactive(
                        EntityNames.SubCategory,
                        EntityNames.MainCategory)
                );
            }

            subCategory.Activate();
            await _subCategoryRepository.UpdateAsync(subCategory);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.SubCategory)
            );
        }
    }
}
