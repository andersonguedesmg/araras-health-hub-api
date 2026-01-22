using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdown
{
    public class GetSupplierDropdownQueryHandler : IRequestHandler<GetSupplierDropdownQuery, PagedResponse<SupplierNameDto>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierDropdownQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<PagedResponse<SupplierNameDto>> Handle(
            GetSupplierDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _supplierRepository
                .GetQueryable()
                .Where(e => e.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(e => e.LegalName.ToLower().Contains(term));
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            queryable = queryable
                .OrderBy(e => e.LegalName)
                .ApplyPagination(request.PageNumber, request.PageSize);

            var items = await queryable
                .Select(e => new SupplierNameDto
                {
                    Id = e.Id,
                    LegalName = e.LegalName,
                    TradeName = e.TradeName
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<SupplierNameDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
