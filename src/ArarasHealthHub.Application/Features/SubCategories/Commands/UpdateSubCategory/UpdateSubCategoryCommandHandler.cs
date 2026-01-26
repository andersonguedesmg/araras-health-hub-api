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
            var existingMainCategory =
                await _mainCategoryRepository.GetByIdAsync(request.Id);

            if (existingMainCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Categoria principal")
                );
            }

            var existingSubCategory =
                await _subCategoryRepository.GetBySubCategoryNameAndMainCategoryIdAsync(request.Name, request.MainCategoryId);

            if (existingSubCategory is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Subcategoria")
                );
            }

            _mapper.Map(request, existingSubCategory);
            existingSubCategory.SetUpdatedOn();

            await _subCategoryRepository.UpdateAsync(existingSubCategory);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.UpdatedSuccessfully("Subcategoria")
            );
        }
    }
}
