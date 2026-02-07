using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, ApiResponse<int>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(
            CreateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var existingSupplier =
                await _supplierRepository.GetByCnpjAsync(request.Cnpj, cancellationToken);

            if (existingSupplier is not null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.CnpjAlreadyExists
                );
            }

            var supplier = _mapper.Map<Supplier>(request);

            await _supplierRepository.AddAsync(supplier, cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.Supplier),
                supplier.Id
            );
        }
    }
}
