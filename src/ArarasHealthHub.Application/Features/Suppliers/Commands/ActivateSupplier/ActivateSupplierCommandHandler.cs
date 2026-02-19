using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.ActivateSupplier
{
    public class ActivateSupplierCommandHandler : IRequestHandler<ActivateSupplierCommand, ApiResponse<object>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public ActivateSupplierCommandHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (supplier is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Supplier)
                );
            }

            if (supplier.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.Supplier)
                );
            }

            supplier.Activate();
            await _supplierRepository.UpdateAsync(supplier, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.Supplier)
            );
        }
    }
}
