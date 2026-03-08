using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Commands.CreateProduct;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(150).WithMessage("Nome não pode exceder 150 caracteres.");


            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descrição é obrigatória.")
                .MaximumLength(200).WithMessage("Descrição não pode exceder 200 caracteres.");

            RuleFor(x => x.MainCategoryId)
                .GreaterThan(0)
                .WithMessage("Categoria Principal inválida.");

            RuleFor(x => x.SubCategoryId)
                .GreaterThan(0)
                .WithMessage("Subcategoria inválida.");

            RuleFor(x => x.PackagingTypeId)
                .GreaterThan(0)
                .WithMessage("Tipo de embalagem inválida.");
        }
    }
}
