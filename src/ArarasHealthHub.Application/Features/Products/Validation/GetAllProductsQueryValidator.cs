using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts;
using ArarasHealthHub.Shared.Core.Pagination;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class GetAllProductsQueryValidator : PagedQueryValidator<GetAllProductsQuery>
    {
        public GetAllProductsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.ToLower() is "name" or "maincategory" or "subcategory" or "presentationform")
                .WithMessage("O campo de ordenação informado não é válido.");
        }
    }
}
