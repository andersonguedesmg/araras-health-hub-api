using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory
{
    public class UpdateMainCategoryCommandHandler : IRequestHandler<UpdateMainCategoryCommand, ApiResponse<bool>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateMainCategoryCommandHandler(IMainCategoryRepository mainCategoryRepository, IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateMainCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingMainCategory = await _mainCategoryRepository.GetByIdAsync(request.Id);

            if (existingMainCategory == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Categoria principal"), false);
            }

            _mapper.Map(request, existingMainCategory);

            existingMainCategory.SetUpdatedOn();

            await _mainCategoryRepository.UpdateAsync(existingMainCategory);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.UpdatedSuccessfully("Categoria principal"), true);
        }
    }
}
