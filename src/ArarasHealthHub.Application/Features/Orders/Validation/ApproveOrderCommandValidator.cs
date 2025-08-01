using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Core;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Orders.Validation
{
    public class ApproveOrderCommandValidator : AbstractValidator<ApproveOrderCommand>
    {
        public ApproveOrderCommandValidator()
        {
            RuleFor(c => c.OrderId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do pedido"));

            RuleFor(c => c.ApprovedByEmployeeId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do funcionário de aprovação"));

            RuleFor(c => c.ApprovedByAccountId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID da conta de aprovação"));

            RuleFor(c => c.OrderItems)
                .NotEmpty().WithMessage("O pedido deve conter pelo menos um item para ser aprovado.");

            RuleForEach(c => c.OrderItems)
                .SetValidator(new ApproveOrderItemDtoValidator());
        }
    }

    public class ApproveOrderItemDtoValidator : AbstractValidator<ApproveOrderItemDto>
    {
        public ApproveOrderItemDtoValidator()
        {
            RuleFor(i => i.OrderItemId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do item de pedido"));

            RuleFor(i => i.ApprovedQuantity)
                .GreaterThan(0).WithMessage("A quantidade aprovada deve ser maior que zero.");
        }
    }
}
