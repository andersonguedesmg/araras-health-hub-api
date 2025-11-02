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

            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("ID do produto inválido.")
                .MustAsync(ProductMustExist).WithMessage("Produto não encontrado.");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(150).WithMessage("O nome do produto não pode exceder 150 caracteres.")
                .MustAsync(BeUniqueProductNameOnUpdate).WithMessage("Já existe um produto cadastrado com este Nome.");

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

        private async Task<bool> ProductMustExist(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.ProductExists(id);
        }

        private async Task<bool> BeUniqueProductNameOnUpdate(UpdateProductCommand command, string name, CancellationToken cancellationToken)
        {
            return await _productRepository.HasProductNameUnique(name, command.Id, cancellationToken);
        }
    }
}
