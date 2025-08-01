using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Core;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.CreatedByEmployeeId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do funcionário"));

            RuleFor(c => c.CreatedByAccountId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID da conta"));

            RuleFor(c => c.OrderItems)
                .NotEmpty().WithMessage("O pedido deve conter pelo menos um item.");

            RuleForEach(c => c.OrderItems)
                .SetValidator(new CreateOrderItemDtoValidator());
        }
    }

    public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
    {
        public CreateOrderItemDtoValidator()
        {
            RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do produto"));

            RuleFor(i => i.RequestedQuantity)
                .GreaterThan(0).WithMessage("A quantidade solicitada deve ser maior que zero.");
        }
    }
}
