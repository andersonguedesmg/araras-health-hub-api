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

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory
{
    public class CreateMainCategoryCommandHandler : IRequestHandler<CreateMainCategoryCommand, ApiResponse<int>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public CreateMainCategoryCommandHandler(IMainCategoryRepository mainCategoryRepository, IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreateMainCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingMainCategory = await _mainCategoryRepository.GetByMainCategoryNameAsync(request.Name);
            if (existingMainCategory != null)
            {
                return new ApiResponse<int>(StatusCodes.Status409Conflict, ApiMessages.MainCategoryAlreadyExists, 0);
            }

            var mainCategory = _mapper.Map<MainCategory>(request);

            await _mainCategoryRepository.AddAsync(mainCategory);

            return new ApiResponse<int>(StatusCodes.Status201Created, ApiMessages.CreatedSuccessfully("Categoria principal"), mainCategory.Id);
        }
    }
}
