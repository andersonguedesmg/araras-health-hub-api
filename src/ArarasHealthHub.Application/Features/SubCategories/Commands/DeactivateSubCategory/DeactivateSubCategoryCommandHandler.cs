using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.DeactivateSubCategory
{
    public class DeactivateSubCategoryCommandHandler : IRequestHandler<DeactivateSubCategoryCommand, ApiResponse<object>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public DeactivateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeactivateSubCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var subCategory =
                await _subCategoryRepository.GetByIdAsync(command.Id);

            if (subCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.SubCategory)
                );
            }

            if (!subCategory.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyInactive(EntityNames.SubCategory)
            );
            }

            subCategory.Deactivate();
            await _subCategoryRepository.UpdateAsync(subCategory);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityDeactivated(EntityNames.SubCategory)
            );
        }
    }
}
