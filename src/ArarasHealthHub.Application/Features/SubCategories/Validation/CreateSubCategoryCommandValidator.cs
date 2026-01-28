using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory;
using ArarasHealthHub.Application.Interfaces.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        public CreateSubCategoryCommandValidator(IApplicationDbContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome não pode exceder 100 caracteres.");

            RuleFor(x => x.MainCategoryId)
                .GreaterThan(0).WithMessage("Categoria Principal inválida.")
                .MustAsync(async (id, ct) =>
                    await context.MainCategories.AnyAsync(c => c.Id == id, ct))
                .WithMessage("Categoria Principal não encontrada.");

            RuleFor(x => x)
                .MustAsync(async (command, ct) =>
                    !await context.SubCategories.AnyAsync(sc =>
                        sc.MainCategoryId == command.MainCategoryId &&
                        sc.Name == command.Name,
                        ct))
                .WithMessage("Já existe uma Subcategoria com este nome para a Categoria Principal informada.");
        }
    }
}
