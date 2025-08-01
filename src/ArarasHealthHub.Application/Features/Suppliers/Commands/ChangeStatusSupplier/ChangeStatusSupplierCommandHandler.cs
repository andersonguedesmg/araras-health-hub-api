using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.ChangeStatusSupplier
{
    public class ChangeStatusSupplierCommandHandler : IRequestHandler<ChangeStatusSupplierCommand, ApiResponse<bool>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public ChangeStatusSupplierCommandHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusSupplierCommand command, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(command.Id);

            if (existingSupplier == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Fornecedor"), false);
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

            var message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Fornecedor") : ApiMessages.DeactivatedSuccessfully("Fornecedor");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
