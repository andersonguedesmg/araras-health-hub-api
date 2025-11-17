using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Stocks.Validation
{
    public class CreateStockAdjustmentCommandValidator : AbstractValidator<CreateStockAdjustmentCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateStockAdjustmentCommandValidator(
            IEmployeeRepository employeeRepository,
            IProductRepository productRepository,
            UserManager<ApplicationUser> userManager
        )
        {
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _userManager = userManager;

            RuleFor(c => c.Type)
                .IsInEnum().WithMessage("O tipo de ajuste é inválido.");

            RuleFor(c => c.Reason)
                .NotEmpty().WithMessage("O motivo do ajuste é obrigatório.")
                .MaximumLength(100).WithMessage("O motivo do ajuste não pode exceder 100 caracteres.");

            RuleFor(c => c.Observation)
                .MaximumLength(200).WithMessage("A observação não pode exceder 200 caracteres.");

            RuleFor(c => c.AdjustmentDate)
                .NotEmpty().WithMessage("A data do ajuste é obrigatória.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data do ajuste não pode ser futura.");

            RuleFor(c => c.ResponsibleId)
                .NotEmpty().WithMessage("O ID do responsável é obrigatório.")
                .MustAsync(EmployeeExists).WithMessage("Responsável não encontrado.");

            RuleFor(c => c.AccountId)
                .NotEmpty().WithMessage(ApiMessages.NotFound("ID da conta de usuário"));

            RuleFor(c => c.AccountId)
                .NotEmpty().WithMessage("O ID da conta é obrigatório.")
                .MustAsync(AccountExists).WithMessage("Conta não encontrada.");

            RuleFor(c => c.AdjustmentItems)
                .NotEmpty().WithMessage("É necessário informar pelo menos um item para o ajuste de estoque.")
                .Must(items => items.Any()).WithMessage("É necessário informar pelo menos um item para o ajuste de estoque.")
                .ForEach(item => item.SetValidator(new AdjustmentItemCommandValidator(_productRepository)));
        }

        private async Task<bool> EmployeeExists(int employeeId, CancellationToken cancellationToken)
        {
            return await _employeeRepository.EmployeeExists(employeeId);
        }

        private async Task<bool> AccountExists(int accountId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(accountId.ToString());
            return user != null;
        }
    }

    public class AdjustmentItemCommandValidator : AbstractValidator<AdjustmentItemCommand>
    {
        private readonly IProductRepository _productRepository;

        public AdjustmentItemCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(i => i.ProductId)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.")
                .MustAsync(ProductExists).WithMessage("Produto não encontrado.");

            RuleFor(i => i.Quantity)
                .NotEqual(0).WithMessage("A quantidade ajustada do item deve ser maior que zero.")
                .GreaterThanOrEqualTo(0).When(i => i.Quantity < 0, ApplyConditionTo.AllValidators)
                .WithMessage("A quantidade do ajuste deve ser positiva. O tipo de ajuste (entrada/saída) deve definir a direção da mudança.");

            RuleFor(i => i.UnitValue)
                .GreaterThanOrEqualTo(0).WithMessage("O valor unitário do item não pode ser negativo.");

            RuleFor(i => i.Batch)
                .NotEmpty().WithMessage("O lote do item é obrigatório.")
                .MaximumLength(50).WithMessage("O lote do item não pode exceder 50 caracteres.");

            RuleFor(i => i.Brand)
                .NotEmpty().WithMessage("A marca do item é obrigatório.")
                .MaximumLength(100).WithMessage("A marca do item não pode exceder 100 caracteres.");
        }

        private async Task<bool> ProductExists(int productId, CancellationToken cancellationToken)
        {
            return await _productRepository.ProductExists(productId);
        }
    }
}
