using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public CreateSubCategoryCommandValidator(ISubCategoryRepository subCategoryRepository, IMainCategoryRepository mainCategoryRepository, IApplicationDbContext context)
        {
            _mainCategoryRepository = mainCategoryRepository;
            _subCategoryRepository = subCategoryRepository;

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome da Subcategoria é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da Subcategoria não pode exceder 100 caracteres.");

            RuleFor(x => x.MainCategoryId).NotEmpty()
                .MustAsync(async (id, ct) => await context.MainCategories.AnyAsync(c => c.Id == id, ct))
                .WithMessage("Categoria Principal inválida.");
        }
    }
}
