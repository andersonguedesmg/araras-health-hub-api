using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, ApiResponse<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SupplierDto>> Handle(
            GetSupplierByIdQuery request,
            CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (supplier is null)
            {
                return ApiResponse<SupplierDto>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Supplier)
                );
            }

            var supplierDto = _mapper.Map<SupplierDto>(supplier);

            return ApiResponse<SupplierDto>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                supplierDto
            );
        }
    }
}
