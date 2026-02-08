using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Commands.CreateProduct;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;

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
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(150)
                    .WithMessage(ValidationMessages.MaxLengthField(150))
                .MustAsync(BeUniqueProductName)
                    .WithMessage("Já existe um produto cadastrado com este nome.");

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithName("Descrição")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(200)
                    .WithMessage(ValidationMessages.MaxLengthField(200));

            RuleFor(x => x.MainCategoryId)
                .GreaterThan(0)
                    .WithName("Categoria Principal")
                    .WithMessage(ValidationMessages.RequiredField)
                .MustAsync(async (id, ct) => await context.MainCategories.AnyAsync(mc => mc.Id == id, ct))
                    .WithMessage("Categoria Principal inválida.");

            RuleFor(x => x.SubCategoryId)
                .GreaterThan(0)
                    .WithName("Subcategoria")
                    .WithMessage(ValidationMessages.RequiredField)
                .MustAsync(async (id, ct) => await context.SubCategories.AnyAsync(sb => sb.Id == id, ct))
                    .WithMessage("Subcategoria inválida.");

            RuleFor(x => x.PresentationFormId)
                .GreaterThan(0)
                    .WithName("Forma de Apresentação")
                    .WithMessage(ValidationMessages.RequiredField)
                .MustAsync(async (id, ct) => await context.PresentationForms.AnyAsync(pf => pf.Id == id, ct))
                    .WithMessage("Forma de Apresentação inválida.");
        }

        private async Task<bool> BeUniqueProductName(string name, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetByProductNameAsync(name, cancellationToken);
            return existingProduct == null;
        }
    }
}
