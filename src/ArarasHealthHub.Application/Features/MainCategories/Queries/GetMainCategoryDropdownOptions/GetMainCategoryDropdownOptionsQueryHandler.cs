using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryDropdownOptions
{
    public class GetMainCategoryDropdownOptionsQueryHandler : IRequestHandler<GetMainCategoryDropdownOptionsQuery, ApiResponse<List<MainCategoryNameDto>>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public GetMainCategoryDropdownOptionsQueryHandler(IMainCategoryRepository mainCategoryRepository, IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<MainCategoryNameDto>>> Handle(GetMainCategoryDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _mainCategoryRepository.GetQueryable();
            query = query
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name);

            var dropdownOptions = await query
                .Select(s => new MainCategoryNameDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<MainCategoryNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
