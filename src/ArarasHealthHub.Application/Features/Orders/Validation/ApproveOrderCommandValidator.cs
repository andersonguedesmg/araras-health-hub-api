using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class ApproveOrderCommandValidator : AbstractValidator<ApproveOrderCommand>
    {
        public ApproveOrderCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0);

            RuleFor(x => x.ApprovedByEmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(new ApproveOrderItemCommandValidator());
        }
    }

    public class ApproveOrderItemCommandValidator : AbstractValidator<ApproveOrderItemCommand>
    {
        public ApproveOrderItemCommandValidator()
        {
            RuleFor(x => x.OrderItemId)
                .GreaterThan(0);

            RuleFor(x => x.ApprovedQuantity)
                .GreaterThan(0);
        }
    }
}
