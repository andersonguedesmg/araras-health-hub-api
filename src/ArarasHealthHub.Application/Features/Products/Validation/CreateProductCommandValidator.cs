using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Commands.CreateProduct;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository, IApplicationDbContext context)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(150)
                    .WithMessage("O nome não pode exceder 150 caracteres.")
                .MustAsync(BeUniqueProductName)
                    .WithMessage("Já existe um produto cadastrado com este nome.");

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("A descrição é obrigatória.")
                .MaximumLength(200)
                    .WithMessage("A descrição não pode exceder 200 caracteres.");

            RuleFor(x => x.MainCategoryId)
                .NotEmpty()
                .MustAsync(async (id, ct) => await context.MainCategories.AnyAsync(c => c.Id == id, ct))
                .WithMessage("Categoria Principal inválida.");

            RuleFor(x => x.SubCategoryId)
                .NotEmpty()
                .MustAsync(async (id, ct) => await context.SubCategories.AnyAsync(c => c.Id == id, ct))
                .WithMessage("Subcategoria inválida.");

            RuleFor(x => x.PresentationFormId)
                .NotEmpty()
                .MustAsync(async (id, ct) => await context.PresentationForms.AnyAsync(c => c.Id == id, ct))
                .WithMessage("Forma de apresentação inválida.");
        }

        private async Task<bool> BeUniqueProductName(string name, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByProductNameAsync(name);
            return existingProduct == null;
        }
    }
}
