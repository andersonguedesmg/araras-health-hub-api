using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.ChangeStatusSupplier
{
    public class ChangeStatusSupplierCommandHandler : IRequestHandler<ChangeStatusSupplierCommand, ApiResponse<object>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public ChangeStatusSupplierCommandHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ChangeStatusSupplierCommand command,
            CancellationToken cancellationToken)
        {
            var existingSupplier =
                await _supplierRepository.GetByIdAsync(command.Id);

            if (existingSupplier is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Fornecedor")
                );
            }

            if (command.IsActive)
            {
                existingSupplier.Activate();
            }
            else
            {
                existingSupplier.Deactivate();
            }

            await _supplierRepository.UpdateAsync(existingSupplier);

            var message = command.IsActive
                ? ApiMessages.ActivatedSuccessfully("Fornecedor")
                : ApiMessages.DeactivatedSuccessfully("Fornecedor");

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                message
            );
        }
    }
}
