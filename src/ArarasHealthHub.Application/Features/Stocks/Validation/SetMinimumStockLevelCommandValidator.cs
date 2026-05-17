using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Commands.SetMinimumStockLevel;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class SetMinimumStockLevelCommandValidator : AbstractValidator<SetMinimumStockLevelCommand>
    {
        public SetMinimumStockLevelCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.MinimumQuantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
