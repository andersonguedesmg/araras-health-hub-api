using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, ApiResponse<object>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public DeleteSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeleteSubCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var existingSubCategory =
                await _subCategoryRepository.GetByIdAsync(request.Id);

            if (existingSubCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Subcategoria")
                );
            }

            await _subCategoryRepository.DeleteAsync(existingSubCategory);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Subcategoria")
            );
        }
    }
}
