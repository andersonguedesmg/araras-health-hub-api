using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Pagination;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, PagedResponse<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<SupplierDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var queryable = _supplierRepository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(s =>
                    s.LegalName.ToLower().Contains(term) ||
                    s.TradeName.ToLower().Contains(term) ||
                    s.Cnpj.ToLower().Contains(term) ||
                    s.Address.Street.ToLower().Contains(term) ||
                    s.Address.Number.ToLower().Contains(term) ||
                    s.Address.Neighborhood.ToLower().Contains(term) ||
                    s.Address.City.ToLower().Contains(term) ||
                    s.Address.State.ToLower().Contains(term) ||
                    s.Address.Cep.ToLower().Contains(term) ||
                    s.Contact.Email.ToLower().Contains(term) ||
                    s.Contact.Phone.ToLower().Contains(term)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var orderingColumns = new Dictionary<string, Expression<Func<Supplier, object>>>
            {
                ["legalName"] = e => e.LegalName,
                ["tradeName"] = e => e.TradeName,
                ["cnpj"] = e => e.Cnpj,
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

            var dtoList = _mapper.Map<IReadOnlyList<SupplierDto>>(items);

            return PagedResponse<SupplierDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtoList
            );
        }
    }
}
