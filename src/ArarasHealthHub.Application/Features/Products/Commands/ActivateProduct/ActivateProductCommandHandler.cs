using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.ActivateProduct
{
    public class ActivateProductCommandHandler : IRequestHandler<ActivateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;

        public ActivateProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(
            ActivateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
                throw new NotFoundException("Produto não foi encontrado.");

            if (product.IsActive)
                throw new BusinessRuleException("O produto já está ativo.");

            product.Activate();

            await _productRepository
                .UpdateAsync(product, cancellationToken);

            return Result.Success("Produto ativado com sucesso.");
        }
    }
}
