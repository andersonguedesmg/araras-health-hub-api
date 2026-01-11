using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Responses;
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
                var searchTerm = request.SearchTerm.Trim().ToLower();

                suppliersQuery = suppliersQuery.Where(s =>
                    s.LegalName.ToLower().Contains(searchTerm) ||
                    s.TradeName.ToLower().Contains(searchTerm) ||
                    s.Cnpj.ToLower().Contains(searchTerm) ||
                    s.Address.Street.ToLower().Contains(searchTerm) ||
                    s.Address.Number.ToLower().Contains(searchTerm) ||
                    s.Address.Neighborhood.ToLower().Contains(searchTerm) ||
                    s.Address.City.ToLower().Contains(searchTerm) ||
                    s.Address.State.ToLower().Contains(searchTerm) ||
                    s.Address.Cep.ToLower().Contains(searchTerm) ||
                    s.Contact.Email.ToLower().Contains(searchTerm) ||
                    s.Contact.Phone.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await suppliersQuery.CountAsync(cancellationToken);

            IOrderedQueryable<Supplier> orderedSuppliers;
            switch (request.OrderBy?.ToLower())
            {
                case "LegalName":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        suppliersQuery.OrderByDescending(s => s.LegalName) :
                        suppliersQuery.OrderBy(s => s.LegalName);
                    break;
                case "TradeName":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        suppliersQuery.OrderByDescending(s => s.TradeName) :
                        suppliersQuery.OrderBy(s => s.TradeName);
                    break;
                case "cnpj":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        suppliersQuery.OrderByDescending(s => s.Cnpj) :
                        suppliersQuery.OrderBy(s => s.Cnpj);
                    break;
                default:
                    orderedSuppliers = suppliersQuery.OrderBy(e => e.LegalName);
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
