using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class CreateStockAdjustmentCommandValidator : AbstractValidator<CreateStockAdjustmentCommand>
    {
        public CreateStockAdjustmentCommandValidator()
        {
            RuleFor(x => x.Type)
                .IsInEnum();

            RuleFor(x => x.Reason)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Observation)
                .MaximumLength(500);

            RuleFor(x => x.AdjustmentDate)
                .LessThanOrEqualTo(DateTime.UtcNow);

            RuleFor(x => x.ResponsibleId)
                .GreaterThan(0);

            RuleFor(x => x.AccountId)
                .GreaterThan(0);

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(
                    new CreateStockAdjustmentItemCommandValidator());
        }
    }

    public class CreateStockAdjustmentItemCommandValidator : AbstractValidator<CreateStockAdjustmentItemCommand>
    {
        public CreateStockAdjustmentItemCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.Quantity)
                .GreaterThan(0);

            RuleFor(x => x.Batch)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Brand)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.UnitValue)
                .GreaterThanOrEqualTo(0)
                .When(x => x.UnitValue.HasValue);

            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.ExpiryDate.HasValue);
        }
    }
}
