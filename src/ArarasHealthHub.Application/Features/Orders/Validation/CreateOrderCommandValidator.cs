using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CreatedByEmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemCommandValidator());
        }
    }

    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.RequestedQuantity)
                .GreaterThan(0);
        }
    }
}
