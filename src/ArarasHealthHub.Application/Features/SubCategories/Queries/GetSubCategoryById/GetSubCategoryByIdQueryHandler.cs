using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, Result<SubCategoryResponse>>
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

            var response = _mapper.Map<SubCategoryResponse>(subCategory);

            return Result<SubCategoryResponse>.Success(
                response,
                "Subcategoria encontrada com sucesso.");
        }
    }
}
