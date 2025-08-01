using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var existingProduct = await _productRepository.GetByProductNameAsync(request.Name);
            if (existingProduct != null)
            {
                return new ApiResponse<int>(StatusCodes.Status409Conflict, ApiMessages.ProductAlreadyExists, 0);
            }

            var product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product);

            return new ApiResponse<int>(StatusCodes.Status201Created, ApiMessages.CreatedSuccessfully("Produto"), product.Id);
        }
    }
}
