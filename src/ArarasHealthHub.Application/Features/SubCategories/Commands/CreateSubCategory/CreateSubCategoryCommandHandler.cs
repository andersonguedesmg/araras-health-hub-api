using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, ApiResponse<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public CreateSubCategoryCommandHandler(
            ISubCategoryRepository subCategoryRepository,
            IMainCategoryRepository mainCategoryRepository,
            IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(
            CreateSubCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var mainCategory = await _mainCategoryRepository
                .GetByIdAsync(request.MainCategoryId, cancellationToken);

            if (mainCategory is null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.MainCategory)
                );
            }

            var alreadyExists = await _subCategoryRepository
                .GetBySubCategoryNameAndMainCategoryIdAsync(
                    request.Name,
                    request.MainCategoryId,
                    cancellationToken);

            if (alreadyExists is not null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyExists(EntityNames.SubCategory)
                );
            }

            var subCategory = _mapper.Map<SubCategory>(request);

            await _subCategoryRepository.AddAsync(subCategory, cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.SubCategory),
                subCategory.Id
            );
        }
    }
}
