using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier
{
    public class DeactivateSupplierCommandHandler : IRequestHandler<DeactivateSupplierCommand, ApiResponse<object>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeactivateSupplierCommandHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeactivateSupplierCommand request,
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

            if (!supplier.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyInactive(EntityNames.Supplier)
                );
            }

            supplier.Deactivate();
            await _supplierRepository.UpdateAsync(supplier, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityDeactivated(EntityNames.Supplier)
            );
        }
    }
}
