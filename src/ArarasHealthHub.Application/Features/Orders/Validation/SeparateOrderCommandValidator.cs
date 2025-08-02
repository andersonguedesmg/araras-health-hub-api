using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Core;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class SeparateOrderCommandValidator : AbstractValidator<SeparateOrderCommand>
    {
        public SeparateOrderCommandValidator()
        {
            RuleFor(c => c.OrderId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do pedido"));

            RuleFor(c => c.SeparatedByEmployeeId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do funcionário de separação"));

            RuleFor(c => c.SeparatedByAccountId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID da conta de separação"));

            RuleFor(c => c.OrderItems)
                .NotEmpty().WithMessage("O pedido deve conter pelo menos um item para ser separado.");

            RuleForEach(c => c.OrderItems)
                .SetValidator(new SeparateOrderItemDtoValidator());
        }
    }

    public class SeparateOrderItemDtoValidator : AbstractValidator<SeparateOrderItemDto>
    {
        public SeparateOrderItemDtoValidator()
        {
            RuleFor(i => i.OrderItemId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do item de pedido"));

            RuleFor(i => i.ActualQuantity)
                .GreaterThan(0).WithMessage("A quantidade separada deve ser maior que zero.");
        }
    }
}
