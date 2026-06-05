using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class FinalizeOrderCommandValidator : AbstractValidator<FinalizeOrderCommand>
    {
        public FinalizeOrderCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0);

            RuleFor(x => x.FinalizedByEmployeeId)
                .GreaterThan(0);
        }
    }
}
