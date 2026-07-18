using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, Result<SubCategoryResponse>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public GetSubCategoryByIdQueryHandler(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<Result<SubCategoryResponse>> Handle(
            GetSubCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var subCategory = await _subCategoryRepository
                .AsQueryableWithMainCategory()
                .FirstOrDefaultAsync(
                    sc => sc.Id == request.Id,
                    cancellationToken);

            if (subCategory is null)
                throw new NotFoundException("Subcategoria não encontrada.");

            var response = new SubCategoryResponse(
                subCategory.Id,
                subCategory.Name,
                subCategory.MainCategoryId,
                subCategory.MainCategory?.Name ?? string.Empty,
                subCategory.CreatedOn,
                subCategory.UpdatedOn,
                subCategory.IsActive
            );

            return Result<SubCategoryResponse>.Success(
                response,
                "Subcategoria encontrada com sucesso.");
        }
    }
}
