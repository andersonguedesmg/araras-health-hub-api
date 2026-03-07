using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, PagedResult<SupplierListItemResponse>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<PagedResult<SupplierListItemResponse>> Handle(
            GetAllSuppliersQuery request,
            CancellationToken cancellationToken)
        {
            var query = _supplierRepository
                .AsQueryable()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(s =>
                    EF.Functions.Like(s.LegalName, $"%{term}%") ||
                    EF.Functions.Like(s.TradeName, $"%{term}%") ||
                    EF.Functions.Like(s.Cnpj, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "legalname" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.LegalName)
                    : query.OrderBy(x => x.LegalName),

                "tradename" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.TradeName)
                    : query.OrderBy(x => x.TradeName),

                "cnpj" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Cnpj)
                    : query.OrderBy(x => x.Cnpj),

                _ => query.OrderBy(x => x.LegalName)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(s => new SupplierListItemResponse(
                    s.Id,
                    s.LegalName,
                    s.TradeName,
                    s.Cnpj,
                    new AddressResponse(
                        s.Address.Street,
                        s.Address.Number,
                        s.Address.Complement,
                        s.Address.Neighborhood,
                        s.Address.City,
                        s.Address.State,
                        s.Address.Cep
                    ),
                    new ContactResponse(
                        s.Contact.Email,
                        s.Contact.Phone
                    ),
                    s.IsActive
                ))
                .ToListAsync(cancellationToken);

            return PagedResult<SupplierListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Fornecedores listados com sucesso.");
        }
    }
}
