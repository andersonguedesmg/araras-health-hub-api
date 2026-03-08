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
        private readonly IMapper _mapper;

        public GetPackagingTypeDropdownQueryHandler(
            IPackagingTypeRepository packagingTypeRepository,
            IMapper mapper)
        {
            _packagingTypeRepository = packagingTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetPackagingTypeDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _packagingTypeRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.IsActive);

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
                .ToListAsync(cancellationToken);

            var response = _mapper.Map<List<DropdownItemResponse>>(items);

            return PagedResult<DropdownItemResponse>.Success(
                response,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Tipos de embalagem listados para seleção.");
        }
    }
}
