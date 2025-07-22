using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, ApiResponse<int>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByCnpjAsync(request.Cnpj);
            if (existingSupplier != null)
            {
                return new ApiResponse<int>(StatusCodes.Status409Conflict, ApiMessages.MsgCnpjAlreadyExists, 0);
            }

            var supplier = _mapper.Map<Supplier>(request);

            await _supplierRepository.CreateAsync(supplier);

            return new ApiResponse<int>(StatusCodes.Status201Created, ApiMessages.MsgSupplierCreatedSuccessfully, supplier.Id);
        }
    }
}
