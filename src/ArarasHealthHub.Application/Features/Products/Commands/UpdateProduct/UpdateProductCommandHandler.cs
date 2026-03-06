using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IPresentationFormRepository _presentationFormRepository;

        public UpdateProductCommandHandler(
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

        public async Task<Result> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product =
                await _productRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (product is null)
                throw new BusinessRuleException("Produto não encontrado.");

            var normalizedName = request.Name.Trim();

            var productWithSameName =
                await _productRepository.GetByProductNameAsync(
                    normalizedName,
                    cancellationToken);

            if (productWithSameName is not null && productWithSameName.Id != request.Id)
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

            product.Update(
                normalizedName,
                request.Description,
                request.MainCategoryId,
                request.SubCategoryId,
                request.PresentationFormId);

            await _productRepository.UpdateAsync(product, cancellationToken);

            return Result.Success("Produto atualizado com sucesso.");
        }
    }
}
