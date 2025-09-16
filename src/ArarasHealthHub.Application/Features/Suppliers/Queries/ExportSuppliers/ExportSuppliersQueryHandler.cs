using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.ExportSuppliers
{
    public class ExportSuppliersQueryHandler : IRequestHandler<ExportSuppliersQuery, IEnumerable<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ExportSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDto>> Handle(ExportSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliersQuery = _supplierRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                suppliersQuery = suppliersQuery.Where(p =>
                    p.Id.ToString().Contains(searchTermLower) ||
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Cnpj.ToLower().Contains(searchTermLower) ||
                    p.Address.ToLower().Contains(searchTermLower) ||
                    p.Number.ToLower().Contains(searchTermLower) ||
                    p.Neighborhood.ToLower().Contains(searchTermLower) ||
                    p.City.ToLower().Contains(searchTermLower) ||
                    p.State.ToLower().Contains(searchTermLower) ||
                    p.Cep.ToLower().Contains(searchTermLower) ||
                    p.Email.ToLower().Contains(searchTermLower) ||
                    p.Phone.ToLower().Contains(searchTermLower) ||
                    p.IsActive.ToString().ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredSuppliers= await suppliersQuery.ToListAsync(cancellationToken);
            var supplierDtos = _mapper.Map<IEnumerable<SupplierDto>>(allFilteredSuppliers);

            return supplierDtos;
        }
    }
}
