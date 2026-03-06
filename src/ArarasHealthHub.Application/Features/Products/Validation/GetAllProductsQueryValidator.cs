using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Products.Validation
{
    public class GetAllProductsQueryValidator : PagedQueryValidator<GetAllProductsQuery>
    {
        public GetAllProductsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                           x.Equals("name", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("maincategory", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("subcategory", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("presentationform", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
