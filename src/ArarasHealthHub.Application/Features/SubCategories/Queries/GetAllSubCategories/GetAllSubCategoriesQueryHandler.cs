using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Pagination;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories
{
    public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, PagedResponse<SubCategoryDto>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllSubCategoriesQueryHandler(
            ISubCategoryRepository subCategoryRepository,
            IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<SubCategoryDto>> Handle(
            GetAllSubCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<SubCategory> query = _subCategoryRepository
                .AsQueryableWithMainCategory();

            if (request.MainCategoryId > 0)
            {
                query = query.Where(sc =>
                    sc.MainCategoryId == request.MainCategoryId);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(sc =>
                    sc.Name.ToLower().Contains(term) ||
                    sc.MainCategory!.Name.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = query.ApplyOrdering(
                request.OrderBy?.ToLower(),
                request.SortOrder.ToLower(),
                new Dictionary<string, Expression<Func<SubCategory, object>>>
                {
                    ["name"] = sc => sc.Name,
                    ["maincategory"] = sc => sc.MainCategory!.Name,
                    ["isactive"] = sc => sc.IsActive
                });

            var items = await query
                .ApplyPagination(request.PageNumber, request.PageSize)
                .ToListAsync(cancellationToken);

            var dtoList = _mapper.Map<IReadOnlyList<SubCategoryDto>>(items);

            return PagedResponse<SubCategoryDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtoList
            );
        }
    }
}
