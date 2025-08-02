using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.AdjustStock;
using ArarasHealthHub.Shared.Core;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class AdjustStockCommandValidator : AbstractValidator<AdjustStockCommand>
    {
        public AdjustStockCommandValidator()
        {
            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do produto"));

            RuleFor(c => c.Quantity)
                .NotEqual(0).WithMessage("A quantidade do ajuste não pode ser zero.");

            RuleFor(c => c.Reason)
                .NotEmpty().WithMessage("O motivo do ajuste é obrigatório.")
                .MaximumLength(250).WithMessage("O motivo deve ter no máximo 250 caracteres.");

            RuleFor(c => c.AdjustedByEmployeeId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID do funcionário responsável"));

            RuleFor(c => c.AdjustedByAccountId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID da conta de usuário"));
        }
    }
}
