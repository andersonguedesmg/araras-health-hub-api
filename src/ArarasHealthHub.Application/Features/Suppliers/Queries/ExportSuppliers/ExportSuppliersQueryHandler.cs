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
                    p.Address.Street.ToLower().Contains(searchTermLower) ||
                    p.Address.Number.ToLower().Contains(searchTermLower) ||
                    p.Address.Neighborhood.ToLower().Contains(searchTermLower) ||
                    p.Address.City.ToLower().Contains(searchTermLower) ||
                    p.Address.State.ToLower().Contains(searchTermLower) ||
                    p.Address.Cep.ToLower().Contains(searchTermLower) ||
                    p.Contact.Email.ToLower().Contains(searchTermLower) ||
                    p.Contact.Phone.ToLower().Contains(searchTermLower) ||
                    p.IsActive.ToString().ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredSuppliers = await suppliersQuery.ToListAsync(cancellationToken);
            var supplierDtos = _mapper.Map<IEnumerable<SupplierDto>>(allFilteredSuppliers);

            return supplierDtos;
        }
    }
}
