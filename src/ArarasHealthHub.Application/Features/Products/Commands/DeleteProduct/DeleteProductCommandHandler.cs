using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse<object>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var existingProduct =
                await _productRepository.GetByIdAsync(request.Id);

            if (existingProduct is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Produto")
                );
            }

            await _productRepository.DeleteAsync(existingProduct);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Produto")
            );
        }
    }
}
