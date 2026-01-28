using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
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
            var mainCategory =
                await _mainCategoryRepository.GetByIdAsync(request.MainCategoryId);

            if (mainCategory is null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Categoria principal")
                );
            }

            var alreadyExists =
                await _subCategoryRepository
                    .GetBySubCategoryNameAndMainCategoryIdAsync(request.Name, request.MainCategoryId);

            if (alreadyExists is not null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.SubCategoryAlreadyExists
                );
            }

            var subCategory = _mapper.Map<SubCategory>(request);

            await _subCategoryRepository.AddAsync(subCategory);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.CreatedSuccessfully("Subcategoria"),
                subCategory.Id
            );
        }
    }
}
