using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.MainCategories.Validation
{
    public class CreateMainCategoryCommandValidator : AbstractValidator<CreateMainCategoryCommand>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public CreateMainCategoryCommandValidator(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome da Categoria principal é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da Categoria principal não pode exceder 100 caracteres.");
        }
    }
}
