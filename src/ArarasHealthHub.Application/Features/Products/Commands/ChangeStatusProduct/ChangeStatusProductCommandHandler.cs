using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Commands.ChangeStatusProduct;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Products.Commands.ChangeStatusProduct
{
    public class ChangeStatusProductCommandHandler : IRequestHandler<ChangeStatusProductCommand, ApiResponse<bool>>
    {
        private readonly IProductRepository _productRepository;

        public ChangeStatusProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusProductCommand command, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByIdAsync(command.Id);

            if (existingProduct == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Produto"), false);
            }

            if (command.IsActive)
            {
                existingProduct.Activate();
            }
            else
            {
                existingProduct.Deactivate();
            }

            string message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Produto") : ApiMessages.DeactivatedSuccessfully("Produto");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
