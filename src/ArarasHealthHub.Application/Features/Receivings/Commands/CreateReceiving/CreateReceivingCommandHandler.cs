using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving
{
    public class CreateReceivingCommandHandler : IRequestHandler<CreateReceivingCommand, ApiResponse<ReceivingDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateReceivingCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreateReceivingCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ILogger<CreateReceivingCommandHandler> logger,
            IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ApiResponse<ReceivingDto>> Handle(CreateReceivingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando criação de novo recebimento com nota {InvoiceNumber}", request.InvoiceNumber);

            var receiving = _mapper.Map<Receiving>(request);

            receiving.Supplier = await _dbContext.Suppliers.FindAsync(request.SupplierId);
            if (receiving.Supplier == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"Fornecedor com ID {request.SupplierId} não encontrado.", false);
            }

            receiving.Responsible = await _dbContext.Employees.FindAsync(request.ResponsibleId);
            if (receiving.Responsible == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"Responsável com ID {request.ResponsibleId} não encontrado.", false);
            }

            var account = await _dbContext.Users.FindAsync(request.AccountId);
            if (account == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"Conta com ID {request.AccountId} não encontrada.", false);
            }

            decimal totalCalculatedValue = 0;

            foreach (var itemCommand in request.ReceivingItems)
            {
                var product = await _dbContext.Products.FindAsync(itemCommand.ProductId);
                if (product == null)
                {
                    return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"Produto com ID {itemCommand.ProductId} não encontrado para o item.", false);
                }

                var receivingItem = _mapper.Map<ReceivingItem>(itemCommand);
                receivingItem.Product = product;
                receivingItem.Receiving = receiving;
                receiving.ReceivingItems.Add(receivingItem);

                var updateStockCommand = new UpdateProductStockCommand(
                    ProductId: itemCommand.ProductId,
                    Quantity: itemCommand.Quantity,
                    OperationType: StockOperationTypeEnum.Receipt
                );

                var stockUpdateResult = await _mediator.Send(updateStockCommand, cancellationToken);
                if (!stockUpdateResult.Success)
                {
                    _logger.LogError("Falha ao atualizar estoque para o produto {ProductId}: {Errors}", itemCommand.ProductId, stockUpdateResult.Message);

                    throw new ApplicationException($"Falha ao atualizar estoque para o produto {itemCommand.ProductId}: {stockUpdateResult.Message}");
                }

                totalCalculatedValue += receivingItem.UnitValue * receivingItem.Quantity;
            }

            receiving.TotalValue = totalCalculatedValue;

            _dbContext.Receivings.Add(receiving);

            _logger.LogInformation("Recebimento {InvoiceNumber} e itens processados. Estoque atualizado.", request.InvoiceNumber);

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);
            return new ApiResponse<ReceivingDto>(
                StatusCodes.Status200OK, // Ou Status201Created se for uma criação
                "Recebimento criado e estoque atualizado com sucesso.",
                receivingDto
            );
        }
    }
}
