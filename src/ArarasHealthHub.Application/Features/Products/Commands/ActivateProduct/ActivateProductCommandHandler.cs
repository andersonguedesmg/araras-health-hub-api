using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Products.Commands.ActivateProduct
{
    public class ActivateProductCommandHandler : IRequestHandler<ActivateProductCommand, ApiResponse<object>>
    {
        private readonly IProductRepository _productRepository;

        public ActivateProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Product)
                );
            }

            if (product.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.Product)
                );
            }

            product.Activate();
            await _productRepository.UpdateAsync(product, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.Product)
            );
        }
    }
}
