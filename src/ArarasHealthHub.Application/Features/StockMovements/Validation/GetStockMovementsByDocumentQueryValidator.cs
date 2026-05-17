using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByDocument;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.StockMovements.Validation
{
    public class GetStockMovementsByDocumentQueryValidator : PagedQueryValidator<GetStockMovementsByDocumentQuery>
    {
        public GetStockMovementsByDocumentQueryValidator()
        {
            RuleFor(x => x.SourceDocumentId)
                .GreaterThan(0);

            RuleFor(x => x.SourceDocumentType)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
