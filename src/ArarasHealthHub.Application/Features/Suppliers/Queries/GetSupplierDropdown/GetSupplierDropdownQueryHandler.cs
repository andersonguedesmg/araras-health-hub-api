using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdown
{
    public class GetSupplierDropdownQueryHandler
        : IRequestHandler<GetSupplierDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierDropdownQueryHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetSupplierDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _supplierRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(s => s.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(s =>
                    EF.Functions.Like(s.LegalName, $"%{term}%") ||
                    EF.Functions.Like(s.TradeName!, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(s => string.IsNullOrWhiteSpace(s.TradeName)
                    ? s.LegalName
                    : s.TradeName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(s => new DropdownItemResponse(
                    s.Id,
                    string.IsNullOrWhiteSpace(s.TradeName)
                        ? s.LegalName
                        : s.TradeName))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Fornecedores listados para seleção.");
        }
    }
}
