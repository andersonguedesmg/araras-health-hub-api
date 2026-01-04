using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Commands.ChangeStatusSubCategory;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class ChangeStatusSubCategoryCommandValidator : AbstractValidator<ChangeStatusSubCategoryCommand>
    {
        public ChangeStatusSubCategoryCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID da Subcategoria é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
