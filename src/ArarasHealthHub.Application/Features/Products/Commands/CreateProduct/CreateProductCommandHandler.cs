using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IPresentationFormRepository _presentationFormRepository;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMainCategoryRepository mainCategoryRepository,
            ISubCategoryRepository subCategoryRepository,
            IPresentationFormRepository presentationFormRepository)
        {
            _productRepository = productRepository;
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _presentationFormRepository = presentationFormRepository;
        }

        public async Task<Result<int>> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var normalizedName = request.Name.Trim();

            var productWithSameName =
                await _productRepository.GetByProductNameAsync(
                    normalizedName,
                    cancellationToken);

            if (productWithSameName is not null)
                throw new BusinessRuleException("Já existe um produto com o nome informado.");

            var mainCategory =
                await _mainCategoryRepository.GetByIdAsync(
                    request.MainCategoryId,
                    cancellationToken);

            if (mainCategory is null || !mainCategory.IsActive)
                throw new BusinessRuleException("Categoria principal inválida ou inativa.");

            var subCategory =
                await _subCategoryRepository.GetByIdAsync(
                    request.SubCategoryId,
                    cancellationToken);

            if (subCategory is null || !subCategory.IsActive)
                throw new BusinessRuleException("Subcategoria inválida ou inativa.");

            if (subCategory.MainCategoryId != request.MainCategoryId)
                throw new BusinessRuleException("A subcategoria não pertence à categoria informada.");

            var presentationForm =
                await _presentationFormRepository.GetByIdAsync(
                    request.PresentationFormId,
                    cancellationToken);

            if (presentationForm is null || !presentationForm.IsActive)
                throw new BusinessRuleException("Forma de apresentação inválida ou inativa.");

            var product = new Product(
                request.Name,
                request.Description,
                request.MainCategoryId,
                request.SubCategoryId,
                request.PresentationFormId
            );

            await _productRepository.AddAsync(product, cancellationToken);

            return Result<int>.Success(
                product.Id,
                "Produto criado com sucesso.");
        }
    }
}
