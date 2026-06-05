using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class CreateReturnOrderCommandValidator : AbstractValidator<CreateReturnOrderCommand>
    {
        public CreateReturnOrderCommandValidator()
        {
            RuleFor(x => x.OriginalOrderId)
                .GreaterThan(0);

            RuleFor(x => x.ReturnedByEmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.Reason)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(500);

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(new CreateReturnOrderItemCommandValidator());
        }
    }

    public class CreateReturnOrderItemCommandValidator : AbstractValidator<CreateReturnOrderItemCommand>
    {
        public CreateReturnOrderItemCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.Quantity)
                .GreaterThan(0);
        }
    }
}
