using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdownOptions
{
    public class GetSubCategoryDropdownOptionsQueryHandler : IRequestHandler<GetSubCategoryDropdownOptionsQuery, ApiResponse<List<SubCategoryNameDto>>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryDropdownOptionsQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<SubCategoryNameDto>>> Handle(GetSubCategoryDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _subCategoryRepository.GetQueryable();
            query = query
                .Where(s => s.IsActive && s.MainCategoryId == request.MainCategoryId)
                .OrderBy(s => s.Name);

            var dropdownOptions = await query
                .Select(s => new SubCategoryNameDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<SubCategoryNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
