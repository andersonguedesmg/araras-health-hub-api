using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Receivings.Validation
{
    public class CreateReceivingCommandValidator : AbstractValidator<CreateReceivingCommand>
    {
        public CreateReceivingCommandValidator()
        {
            RuleFor(x => x.InvoiceNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.SupplyAuthorization)
                .MaximumLength(50);

            RuleFor(x => x.ReceivingDate)
                .LessThanOrEqualTo(DateTime.UtcNow);

            RuleFor(x => x.SupplierId)
                .GreaterThan(0);

            RuleFor(x => x.ResponsibleId)
                .GreaterThan(0);

            RuleFor(x => x.AccountId)
                .GreaterThan(0);

            RuleFor(x => x.ReceivedItems)
                .NotEmpty();

            RuleForEach(x => x.ReceivedItems)
                .SetValidator(
                    new CreateReceivedItemCommandValidator());
        }
    }

    public class CreateReceivedItemCommandValidator : AbstractValidator<CreateReceivedItemCommand>
    {
        public CreateReceivedItemCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0);

            RuleFor(x => x.UnitValue)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Batch)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Brand)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.UtcNow);

            RuleFor(x => x.ProductId)
                .GreaterThan(0);
        }
    }
}
