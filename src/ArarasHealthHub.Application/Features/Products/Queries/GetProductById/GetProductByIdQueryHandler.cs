using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByIdAsync(request.Id);

            if (products == null)
            {
                return new ApiResponse<ProductDto>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, null!);
            }

            var productDto = _mapper.Map<ProductDto>(products);

            return new ApiResponse<ProductDto>(StatusCodes.Status200OK, ApiMessages.MsgSupplierFoundSuccessfully, productDto);
        }
    }
}
