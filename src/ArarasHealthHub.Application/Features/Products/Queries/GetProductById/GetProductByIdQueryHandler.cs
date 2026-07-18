using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductResponse>> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
                throw new NotFoundException("Produto não foi encontrado.");

            var response = new ProductResponse(
                product.Id,
                product.Name,
                product.Description,
                product.MainCategoryId,
                product.MainCategory?.Name ?? string.Empty,
                product.SubCategoryId,
                product.SubCategory?.Name ?? string.Empty,
                product.PackagingTypeId,
                product.PackagingType?.Name ?? string.Empty,
                product.CreatedOn,
                product.UpdatedOn,
                product.IsActive
            );

            return Result<ProductResponse>.Success(
                response,
                "Produto encontrado com sucesso.");
        }
    }
}
