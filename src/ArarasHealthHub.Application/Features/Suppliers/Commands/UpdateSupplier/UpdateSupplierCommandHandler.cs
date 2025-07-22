using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, ApiResponse<bool>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (existingSupplier == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, false);
            }

            if (existingSupplier.Cnpj != request.Cnpj)
            {
                var supplierWithSameCnpj = await _supplierRepository.GetByCnpjAsync(request.Cnpj);
                if (supplierWithSameCnpj != null && supplierWithSameCnpj.Id != request.Id)
                {
                    return new ApiResponse<bool>(StatusCodes.Status409Conflict, ApiMessages.MsgCnpjAlreadyExists, false);
                }
            }

            _mapper.Map(request, existingSupplier);

            await _supplierRepository.UpdateAsync(existingSupplier);

            return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.MsgSupplierUpdatedSuccessfully, true);
        }
    }
}
