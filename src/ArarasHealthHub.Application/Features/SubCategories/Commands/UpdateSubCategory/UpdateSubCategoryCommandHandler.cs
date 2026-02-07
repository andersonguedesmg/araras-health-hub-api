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

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, ApiResponse<object>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository,
            IMainCategoryRepository mainCategoryRepository,
            IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<object>> Handle(
            UpdateSubCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (subCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.SubCategory)
                );
            }

            var mainCategory = await _mainCategoryRepository
                .GetByIdAsync(request.MainCategoryId, cancellationToken);

            if (mainCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.MainCategory)
                );
            }

            var duplicate = await _subCategoryRepository
                .GetBySubCategoryNameAndMainCategoryIdAsync(
                    request.Name,
                    request.MainCategoryId);

            if (duplicate is not null && duplicate.Id != request.Id)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyExists(EntityNames.SubCategory)
                );
            }

            _mapper.Map(request, subCategory);
            subCategory.SetUpdatedOn();

            await _subCategoryRepository.UpdateAsync(subCategory, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityUpdated(EntityNames.SubCategory)
            );
        }
    }
}
