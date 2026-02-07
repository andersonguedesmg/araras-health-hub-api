using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdown
{
    public class GetSupplierDropdownQueryHandler : IRequestHandler<GetSupplierDropdownQuery, PagedResponse<DropdownItemDto>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierDropdownQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<PagedResponse<DropdownItemDto>> Handle(
            GetSupplierDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _supplierRepository
                .AsQueryable()
                .Where(e => e.IsActive);

            var term = request.SearchTerm?.Trim();

            if (!string.IsNullOrWhiteSpace(term))
            {
                var search = term.ToLower();

                queryable = queryable.Where(e =>
                    e.LegalName.ToLower().Contains(search)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var items = await queryable
                .OrderBy(x => x.LegalName)
                .ApplyPagination(request.PageNumber, request.PageSize)
                .Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Label = x.LegalName
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<DropdownItemDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
