using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, ApiResponse<object>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<object>> Handle(
            UpdateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var existingSupplier =
                await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (existingSupplier is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Supplier)
                );
            }

            var duplicateCnpjSupplier =
                await _supplierRepository.GetByCnpjAsync(request.Cnpj, cancellationToken);

            if (duplicateCnpjSupplier is not null && duplicateCnpjSupplier.Id != request.Id)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.CnpjAlreadyExists
                );
            }

            _mapper.Map(request, existingSupplier);
            existingSupplier.SetUpdatedOn();

            await _supplierRepository.UpdateAsync(existingSupplier, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityUpdated(EntityNames.Supplier)
            );
        }
    }
}
