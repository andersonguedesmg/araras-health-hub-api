using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductResponse>> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {

            var product = await _productRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
                throw new NotFoundException("Produto não foi encontrado.");

            var response = _mapper.Map<ProductResponse>(product);

            return Result<ProductResponse>.Success(
                response,
                "Produto encontrado com sucesso.");
        }
    }
}
