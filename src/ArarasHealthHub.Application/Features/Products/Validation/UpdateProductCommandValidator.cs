using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;

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
                    .WithMessage(ValidationMessages.InvalidId);

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(150)
                    .WithMessage(ValidationMessages.MaxLengthField(150))
                .MustAsync(BeUniqueProductNameOnUpdate)
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

        private async Task<bool> BeUniqueProductNameOnUpdate(UpdateProductCommand command, string name, CancellationToken cancellationToken)
        {
            return await _productRepository.HasProductNameUnique(name, command.Id, cancellationToken);
        }
    }
}
