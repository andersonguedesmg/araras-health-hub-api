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
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, ApiResponse<List<SupplierDto>>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<SupplierDto>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            if (suppliers == null || !suppliers.Any())
            {
                return new ApiResponse<List<SupplierDto>>(StatusCodes.Status404NotFound, ApiMessages.MsgNotSuppliersFound, null!);
            }

            var supplierDtos = _mapper.Map<List<SupplierDto>>(suppliers);

            return new ApiResponse<List<SupplierDto>>(StatusCodes.Status200OK, ApiMessages.MsgSuppliersFoundSuccessfully, supplierDtos);
        }
    }
}
