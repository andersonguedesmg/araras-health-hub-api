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
                suppliersQuery = suppliersQuery.Where(s =>
                    s.LegalName.ToLower().Contains(searchTermLower) ||
                    s.TradeName.ToLower().Contains(searchTermLower) ||
                    s.Cnpj.ToLower().Contains(searchTermLower) ||
                    s.Address.Street.ToLower().Contains(searchTermLower) ||
                    s.Address.Number.ToLower().Contains(searchTermLower) ||
                    s.Address.Neighborhood.ToLower().Contains(searchTermLower) ||
                    s.Address.City.ToLower().Contains(searchTermLower) ||
                    s.Address.State.ToLower().Contains(searchTermLower) ||
                    s.Address.Cep.ToLower().Contains(searchTermLower) ||
                    s.Contact.Email.ToLower().Contains(searchTermLower) ||
                    s.Contact.Phone.ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredSuppliers = await suppliersQuery.OrderBy(s => s.LegalName).ToListAsync(cancellationToken);
            var supplierDtos = _mapper.Map<IEnumerable<SupplierDto>>(allFilteredSuppliers);

            return supplierDtos;
        }
    }
}
