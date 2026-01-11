using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories
{
    public class GetAllMainCategoriesQueryHandler : IRequestHandler<GetAllMainCategoriesQuery, PagedResponse<MainCategoryDto>>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllMainCategoriesQueryHandler(IMainCategoryRepository mainCategoryRepository, IMapper mapper)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<MainCategoryDto>> Handle(GetAllMainCategoriesQuery request, CancellationToken cancellationToken)
        {
            var mainCategoriesQuery = _mainCategoryRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();

                mainCategoriesQuery = mainCategoriesQuery.Where(e =>
                    e.Name.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await mainCategoriesQuery.CountAsync(cancellationToken);

            IOrderedQueryable<MainCategory> orderedQuery;
            switch (request.OrderBy?.ToLower())
            {
                case "name":
                    orderedQuery = request.SortOrder?.ToLower() == "desc"
                        ? mainCategoriesQuery.OrderByDescending(p => p.Name)
                        : mainCategoriesQuery.OrderBy(p => p.Name);
                    break;
                default:
                    orderedQuery = mainCategoriesQuery.OrderBy(e => e.Name);
                    break;
            }

            var pagedMainCategories = await orderedQuery
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var mainCategoryDtos = _mapper.Map<List<MainCategoryDto>>(pagedMainCategories);

            return new PagedResponse<MainCategoryDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                mainCategoryDtos
            );
        }
    }
}
