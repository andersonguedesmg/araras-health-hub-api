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

        public async Task<ApiResponse<bool>> Handle(ChangeStatusSupplierCommand request, CancellationToken cancellationToken)
        {
            var existingSupplier = await _supplierRepository.GetByIdAsync(request.Id);

            if (existingSupplier == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, false);
            }

            if (existingSupplier.IsActive == request.IsActive)
            {
                return new ApiResponse<bool>(StatusCodes.Status200OK, ApiMessages.MsgSupplierStatusAlreadyAsDesired, true);
            }

            existingSupplier.IsActive = request.IsActive;
            existingSupplier.UpdatedOn = DateTime.UtcNow;

            await _supplierRepository.UpdateAsync(existingSupplier);

            string successMessage = request.IsActive ? ApiMessages.MsgSupplierActivatedSuccessfully : ApiMessages.MsgSupplierDisabledSuccessfully;
            return new ApiResponse<bool>(StatusCodes.Status200OK, successMessage, true);
        }
    }
}
