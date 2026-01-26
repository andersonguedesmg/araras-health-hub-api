using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Pagination;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetAllPresentationForms
{
    public class GetAllPresentationFormsQueryHandler : IRequestHandler<GetAllPresentationFormsQuery, PagedResponse<PresentationFormDto>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;
        private readonly IMapper _mapper;

        public GetAllPresentationFormsQueryHandler(
            IPresentationFormRepository presentationFormRepository,
            IMapper mapper)
        {
            _presentationFormRepository = presentationFormRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<PresentationFormDto>> Handle(
            GetAllPresentationFormsQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _presentationFormRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(p =>
                    p.Name.ToLower().Contains(term)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var orderingColumns = new Dictionary<string, Expression<Func<PresentationForm, object>>>
            {
                ["name"] = p => p.Name,
            };

            queryable = queryable.ApplyOrdering(
                request.OrderBy?.ToLower(),
                request.SortOrder?.ToLower() ?? "asc",
                orderingColumns
            );

            queryable = queryable.ApplyPagination(
                request.PageNumber,
                request.PageSize
            );

            var items = await queryable.ToListAsync(cancellationToken);

            var dtoList = _mapper.Map<IReadOnlyList<PresentationFormDto>>(items);

            return PagedResponse<PresentationFormDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtoList
            );
        }
    }
}
