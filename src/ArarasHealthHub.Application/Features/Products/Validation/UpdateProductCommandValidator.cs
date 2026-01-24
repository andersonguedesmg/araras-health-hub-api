using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandValidator(IProductRepository productRepository, IApplicationDbContext context)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador do produto é inválido.");

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(150)
                    .WithMessage("O nome não pode exceder 150 caracteres.")
                .MustAsync(BeUniqueProductNameOnUpdate)
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

        private async Task<bool> BeUniqueProductNameOnUpdate(UpdateProductCommand command, string name, CancellationToken cancellationToken)
        {
            return await _productRepository.HasProductNameUnique(name, command.Id, cancellationToken);
        }
    }
}
