using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class SeparateOrderCommandValidator : AbstractValidator<SeparateOrderCommand>
    {
        public SeparateOrderCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0);

            RuleFor(x => x.SeparatedByEmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.OrderItems)
                .NotEmpty();

            RuleForEach(x => x.OrderItems)
                .SetValidator(new SeparateOrderItemCommandValidator());
        }
    }

    public class SeparateOrderItemCommandValidator : AbstractValidator<SeparateOrderItemCommand>
    {
        public SeparateOrderItemCommandValidator()
        {
            RuleFor(x => x.OrderItemId)
                .GreaterThan(0);

            RuleFor(x => x.ActualQuantity)
                .GreaterThan(0);
        }
    }
}
