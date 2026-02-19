using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Messages;

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

            RuleFor(i => i.ProductId)
                .GreaterThan(0).WithMessage(ApiMessages.NotFound("ID do produto"));

            RuleFor(i => i.ActualQuantity)
                .GreaterThan(0).WithMessage("A quantidade separada deve ser maior que zero.");

            RuleFor(i => i.SeparatedLots)
                .NotEmpty().WithMessage("É obrigatório informar o(s) lote(s) utilizado(s) na separação do item.");

            RuleForEach(i => i.SeparatedLots)
                .ChildRules(lots =>
                {
                    lots.RuleFor(l => l.Batch)
                        .NotEmpty().WithMessage("O número do lote (Batch) é obrigatório.");

                    lots.RuleFor(l => l.Quantity)
                        .GreaterThan(0).WithMessage("A quantidade do lote deve ser maior que zero.");
                });

            RuleFor(i => i)
                .Must(i => i.SeparatedLots.Sum(l => l.Quantity) == i.ActualQuantity)
                .WithMessage("A soma das quantidades dos lotes separados deve ser igual à quantidade total separada (ActualQuantity).");
        }
    }
}
