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

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, ApiResponse<SubCategoryDto>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetSubCategoryByIdQueryHandler(
            ISubCategoryRepository subCategoryRepository,
            IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SubCategoryDto>> Handle(
            GetSubCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryRepository
                .GetQueryable()
                .Include(sc => sc.MainCategory)
                .FirstOrDefaultAsync(sc => sc.Id == request.Id, cancellationToken);

            if (subCategory is null)
            {
                return ApiResponse<SubCategoryDto>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Subcategoria")
                );
            }

            var dto = _mapper.Map<SubCategoryDto>(subCategory);

            return ApiResponse<SubCategoryDto>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dto
            );
        }
    }
}
