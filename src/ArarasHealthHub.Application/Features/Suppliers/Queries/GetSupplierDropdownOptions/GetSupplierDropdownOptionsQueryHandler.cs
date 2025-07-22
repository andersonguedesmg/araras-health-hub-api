using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdownOptions
{
    public class GetSupplierDropdownOptionsQueryHandler : IRequestHandler<GetSupplierDropdownOptionsQuery, ApiResponse<List<SupplierNameDto>>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierDropdownOptionsQueryHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<List<SupplierNameDto>>> Handle(GetSupplierDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            suppliers = suppliers.Where(s => s.IsActive).ToList();

            if (suppliers == null || !suppliers.Any())
            {
                return new ApiResponse<List<SupplierNameDto>>(StatusCodes.Status404NotFound, ApiMessages.MsgNotSuppliersFound, null!);
            }

            var supplierNames = suppliers.Select(s => new SupplierNameDto
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return new ApiResponse<List<SupplierNameDto>>(StatusCodes.Status200OK, ApiMessages.MsgSuppliersFoundSuccessfully, supplierNames);
        }
    }
}
