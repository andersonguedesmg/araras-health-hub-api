using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Receivings.Validation
{
    public class CreateReceivingCommandValidator : AbstractValidator<CreateReceivingCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateReceivingCommandValidator(
            ISupplierRepository supplierRepository,
            IEmployeeRepository employeeRepository,
            IProductRepository productRepository,
            UserManager<ApplicationUser> userManager)
        {
            _supplierRepository = supplierRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _userManager = userManager;

            RuleFor(r => r.InvoiceNumber)
                .NotEmpty().WithMessage("O número da nota fiscal é obrigatório.")
                .MaximumLength(50).WithMessage("O número da nota fiscal não pode exceder 50 caracteres.");

            RuleFor(r => r.SupplyAuthorization)
                .NotEmpty().WithMessage("A autorização de fornecimento é obrigatória.")
                .MaximumLength(50).WithMessage("A autorização de fornecimento não pode exceder 50 caracteres.");

            RuleFor(r => r.ReceivingDate)
                .NotEmpty().WithMessage("A data de recebimento é obrigatória.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de recebimento não pode ser futura.");

            RuleFor(r => r.SupplierId)
                .NotEmpty().WithMessage("O ID do fornecedor é obrigatório.")
                .MustAsync(SupplierExists).WithMessage("Fornecedor não encontrado.");

            RuleFor(r => r.ResponsibleId)
                .NotEmpty().WithMessage("O ID do responsável é obrigatório.")
                .MustAsync(EmployeeExists).WithMessage("Responsável não encontrado.");

            RuleFor(r => r.AccountId)
                .NotEmpty().WithMessage("O ID da conta é obrigatório.")
                .MustAsync(AccountExists).WithMessage("Conta não encontrada.");

            RuleFor(r => r.ReceivedItems)
                .NotEmpty().WithMessage("Um recebimento deve ter pelo menos um item.");

            RuleForEach(r => r.ReceivedItems).SetValidator(new CreateReceivingItemCommandValidator(_productRepository));
        }

        private async Task<bool> SupplierExists(int supplierId, CancellationToken cancellationToken)
        {
            return await _supplierRepository.SupplierExists(supplierId);
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

    public class CreateReceivingItemCommandValidator : AbstractValidator<CreateReceivingItemCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateReceivingItemCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("A quantidade do item deve ser maior que zero.");

            RuleFor(item => item.UnitValue)
                .GreaterThanOrEqualTo(0).WithMessage("O valor unitário do item não pode ser negativo.");

            RuleFor(item => item.Batch)
                .NotEmpty().WithMessage("O lote do item é obrigatório.")
                .MaximumLength(50).WithMessage("O lote do item não pode exceder 50 caracteres.");

            RuleFor(item => item.ExpiryDate)
                .NotEmpty().WithMessage("A data de validade do item é obrigatória.")
                .GreaterThan(DateTime.UtcNow).WithMessage("A data de validade do item deve ser futura.");

            RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.")
                .MustAsync(ProductExists).WithMessage("Produto não encontrado.");
        }

        private async Task<bool> ProductExists(int productId, CancellationToken cancellationToken)
        {
            return await _productRepository.ProductExists(productId);
        }
    }
}
