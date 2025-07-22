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
            var allSuppliers = await _supplierRepository.GetAllAsync();

            var totalCount = allSuppliers.Count();

            IOrderedEnumerable<Supplier> orderedSuppliers;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        allSuppliers.OrderByDescending(s => s.Name) :
                        allSuppliers.OrderBy(s => s.Name);
                    break;
                case "cnpj":
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        allSuppliers.OrderByDescending(s => s.Cnpj) :
                        allSuppliers.OrderBy(s => s.Cnpj);
                    break;
                default:
                    orderedSuppliers = request.SortOrder.ToLower() == "desc" ?
                        allSuppliers.OrderByDescending(s => s.Id) :
                        allSuppliers.OrderBy(s => s.Id);
                    break;
            }

            var pagedSuppliers = orderedSuppliers
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

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
