using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do produto não pode exceder 150 caracteres.")
                .MustAsync(BeUniqueProduct).WithMessage("Já existe um produto cadastrado com este Nome.");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                .MaximumLength(200).WithMessage("A descrição do produto não pode exceder 200 caracteres.");

            RuleFor(command => command.MainCategory)
                .NotEmpty().WithMessage("A categoria principal do produto é obrigatória.")
                .MaximumLength(100).WithMessage("A categoria principal do produto não pode exceder 100 caracteres.");

            RuleFor(command => command.SubCategory)
                .NotEmpty().WithMessage("A subcategoria do produto é obrigatória.")
                .MaximumLength(100).WithMessage("A subcategoria do produto não pode exceder 100 caracteres.");

            RuleFor(command => command.PresentationForm)
                .NotEmpty().WithMessage("A forma de apresentação do produto é obrigatória.")
                .MaximumLength(100).WithMessage("A forma de apresentação do produto não pode exceder 100 caracteres.");
        }

        private async Task<bool> BeUniqueProduct(string cnpj, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByProductNameAsync(cnpj);
            return existingProduct == null;
        }
    }
}
