using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.DeactivateProduct
{
    public class DeactivateProductCommandHandler : IRequestHandler<DeactivateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public DeactivateProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(
            DeactivateProductCommand request,
            CancellationToken cancellationToken)
        {

            var product = await _productRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
                throw new NotFoundException("Produto não foi encontrado.");

            if (!product.IsActive)
                throw new BusinessRuleException("O produto já está inativo.");

            product.Deactivate();

            await _productRepository
                .UpdateAsync(product, cancellationToken);

            return Result.Success("Produto desativado com sucesso.");
        }
    }
}
