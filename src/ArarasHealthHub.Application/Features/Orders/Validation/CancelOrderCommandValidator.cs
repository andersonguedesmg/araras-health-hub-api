using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0);

            RuleFor(x => x.CanceledByEmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.CancellationReason)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(500);
        }
    }
}
