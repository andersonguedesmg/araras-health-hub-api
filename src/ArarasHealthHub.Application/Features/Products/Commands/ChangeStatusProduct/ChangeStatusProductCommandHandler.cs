using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Products.Commands.ChangeStatusProduct
{
    public class ChangeStatusProductCommandHandler : IRequestHandler<ChangeStatusProductCommand, ApiResponse<object>>
    {
        private readonly IProductRepository _productRepository;

        public ChangeStatusProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ChangeStatusProductCommand command,
            CancellationToken cancellationToken)
        {
            var existingProduct =
                await _productRepository.GetByIdAsync(command.Id);

            if (existingProduct is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Produto")
                );
            }

            if (command.IsActive)
            {
                existingProduct.Activate();
            }
            else
            {
                existingProduct.Deactivate();
            }

            await _productRepository.UpdateAsync(existingProduct);

            var message = command.IsActive
                ? ApiMessages.ActivatedSuccessfully("Produto")
                : ApiMessages.DeactivatedSuccessfully("Produto");

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                message
            );
        }
    }
}
