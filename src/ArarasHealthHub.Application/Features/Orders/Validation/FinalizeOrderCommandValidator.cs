using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;
using ArarasHealthHub.Shared.Core;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class FinalizeOrderCommandValidator : AbstractValidator<FinalizeOrderCommand>
    {
        public FinalizeOrderCommandValidator()
        {
            RuleFor(c => c.OrderId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do pedido"));

            RuleFor(c => c.FinalizedByEmployeeId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do funcionário de finalização"));

            RuleFor(c => c.FinalizedByAccountId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID da conta de finalização"));
        }
    }
}
