using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryById
{
    public class GetMainCategoryByIdQueryHandler : IRequestHandler<GetMainCategoryByIdQuery, ApiResponse<MainCategoryDto>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public GetMainCategoryByIdQueryHandler(
            IMainCategoryRepository mainCategoryRepository,
            IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<MainCategoryDto>> Handle(
            GetMainCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var mainCategory = await _mainCategoryRepository.GetByIdAsync(request.Id);

            if (mainCategory is null)
            {
                return ApiResponse<MainCategoryDto>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Categoria principal")
                );
            }

            var mainCategoryDto = _mapper.Map<MainCategoryDto>(mainCategory);

            return ApiResponse<MainCategoryDto>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.FoundSuccessfully("Categoria principal"),
                mainCategoryDto
            );
        }
    }
}
