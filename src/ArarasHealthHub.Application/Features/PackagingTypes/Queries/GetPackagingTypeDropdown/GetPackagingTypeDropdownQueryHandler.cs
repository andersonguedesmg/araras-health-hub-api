using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetPackagingTypeDropdown
{
    public class GetPackagingTypeDropdownQueryHandler : IRequestHandler<GetPackagingTypeDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public GetPackagingTypeDropdownQueryHandler(
            IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetPackagingTypeDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _packagingTypeRepository
                .AsQueryable()
                .AsNoTracking();

            if (request.IsActive.HasValue)
            {
                query = query.Where(s => s.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(p =>
                    EF.Functions.Like(p.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(p => p.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new DropdownItemResponse(
                    p.Id,
                    p.Name))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Tipos de embalagem listados para seleção.");
        }
    }
}
