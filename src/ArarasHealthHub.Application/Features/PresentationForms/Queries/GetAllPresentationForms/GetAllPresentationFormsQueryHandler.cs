using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PresentationForms.Queries.GetAllPresentationForms
{
    public class GetAllPresentationFormsQueryHandler : IRequestHandler<GetAllPresentationFormsQuery, PagedResult<PresentationFormListItemResponse>>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public GetAllPresentationFormsQueryHandler(
            IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<PagedResult<PresentationFormListItemResponse>> Handle(
            GetAllPresentationFormsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _presentationFormRepository
                .AsQueryable()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(pf =>
                    EF.Functions.Like(pf.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(pf => pf.Name)
                    : query.OrderBy(pf => pf.Name),

                _ => query.OrderBy(pf => pf.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(pf => new PresentationFormListItemResponse(
                    pf.Id,
                    pf.Name,
                    pf.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<PresentationFormListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Formas de apresentação listadas com sucesso.");
        }
    }
}
