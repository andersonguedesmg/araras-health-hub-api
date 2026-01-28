using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.SubCategories.Validation
{
    public class GetSubCategoryByIdQueryValidator : AbstractValidator<GetSubCategoryByIdQuery>
    {
        public GetSubCategoryByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador da subcategoria é inválido.");
        }
    }
}
