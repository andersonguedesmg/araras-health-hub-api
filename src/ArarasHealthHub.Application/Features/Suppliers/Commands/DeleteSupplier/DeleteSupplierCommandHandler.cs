using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, ApiResponse<object>>
    {
        private readonly ISupplierRepository _supplierRepository;

        public DeleteSupplierCommandHandler(
            ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeleteSupplierCommand request,
            CancellationToken cancellationToken)
        {
            var existingSupplier =
                await _supplierRepository.GetByIdAsync(request.Id);

            if (existingSupplier is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Fornecedor")
                );
            }

            await _supplierRepository.DeleteAsync(existingSupplier);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Fornecedor")
            );
        }
    }
}
