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
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, ApiResponse<bool>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMainCategoryRepository mainCategoryRepository, IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingMainCategory = await _mainCategoryRepository.GetByIdAsync(request.MainCategoryId);
            if (existingMainCategory != null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MainCategoryDoesNotExist, false);
            }

            var existingSubCategory = await _subCategoryRepository.GetByIdAsync(request.Id);

            if (existingSubCategory == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Subcategoria"), false);
            }

            _mapper.Map(request, existingSubCategory);

            existingSubCategory.SetUpdatedOn();

            await _subCategoryRepository.UpdateAsync(existingSubCategory);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.UpdatedSuccessfully("Subcategoria"), true);
        }
    }
}
