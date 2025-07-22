using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdownOptions
{
    public class GetSupplierDropdownOptionsQueryHandler : IRequestHandler<GetSupplierDropdownOptionsQuery, ApiResponse<List<SupplierNameDto>>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierDropdownOptionsQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<SupplierNameDto>>> Handle(GetSupplierDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _supplierRepository.AsQueryable();

            query = query.Where(s => s.IsActive);

            query = query.OrderBy(s => s.Name);

            var activeSuppliers = await query.ToListAsync(cancellationToken);

            var dropdownOptions = _mapper.Map<List<SupplierNameDto>>(activeSuppliers);

            return new ApiResponse<List<SupplierNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.MsgOperationSuccessful,
                dropdownOptions
            );
        }
    }
}
