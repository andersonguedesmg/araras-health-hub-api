using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, PagedResponse<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<SupplierDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliersQuery = _supplierRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                suppliersQuery = suppliersQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Cnpj.ToLower().Contains(searchTermLower) ||
                    p.Address.Street.ToLower().Contains(searchTermLower) ||
                    p.Address.Number.ToLower().Contains(searchTermLower) ||
                    p.Address.Neighborhood.ToLower().Contains(searchTermLower) ||
                    p.Address.City.ToLower().Contains(searchTermLower) ||
                    p.Address.State.ToLower().Contains(searchTermLower) ||
                    p.Address.Cep.ToLower().Contains(searchTermLower) ||
                    p.Contact.Email.ToLower().Contains(searchTermLower) ||
                    p.Contact.Phone.ToLower().Contains(searchTermLower)
                );
            }

            var totalCount = await suppliersQuery.CountAsync(cancellationToken);

            IQueryable<Supplier> orderedSuppliers;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        suppliersQuery.OrderByDescending(s => s.Name) :
                        suppliersQuery.OrderBy(s => s.Name);
                    break;
                case "cnpj":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        suppliersQuery.OrderByDescending(s => s.Cnpj) :
                        suppliersQuery.OrderBy(s => s.Cnpj);
                    break;
                default:
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        suppliersQuery.OrderByDescending(s => s.Id) :
                        suppliersQuery.OrderBy(s => s.Id);
                    break;
            }

            var pagedSuppliers = await orderedSuppliers
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var supplierDtos = _mapper.Map<List<SupplierDto>>(pagedSuppliers);

            return new PagedResponse<SupplierDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                supplierDtos
            );
        }
    }
}
