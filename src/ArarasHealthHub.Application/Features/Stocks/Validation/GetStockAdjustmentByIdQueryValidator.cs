using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustmentById;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class GetStockAdjustmentByIdQueryValidator : AbstractValidator<GetStockAdjustmentByIdQuery>
    {
        public GetStockAdjustmentByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
