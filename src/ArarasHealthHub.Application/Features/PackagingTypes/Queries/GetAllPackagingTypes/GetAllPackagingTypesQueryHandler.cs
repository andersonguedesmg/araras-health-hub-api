using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetAllPackagingTypes
{
    public class GetAllPackagingTypesQueryHandler : IRequestHandler<GetAllPackagingTypesQuery, PagedResult<PackagingTypeListItemResponse>>
    {
        private readonly IPackagingTypeRepository _packagingTypeRepository;

        public GetAllPackagingTypesQueryHandler(
            IPackagingTypeRepository packagingTypeRepository)
        {
            _packagingTypeRepository = packagingTypeRepository;
        }

        public async Task<PagedResult<PackagingTypeListItemResponse>> Handle(
            GetAllPackagingTypesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _packagingTypeRepository
                .AsQueryable()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(p =>
                    EF.Functions.Like(p.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(p => p.Name)
                    : query.OrderBy(p => p.Name),

                _ => query.OrderBy(p => p.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(sc => new PackagingTypeListItemResponse(
                    sc.Id,
                    sc.Name,
                    sc.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<PackagingTypeListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Tipos de embalagem listados com sucesso.");
        }
    }
}
