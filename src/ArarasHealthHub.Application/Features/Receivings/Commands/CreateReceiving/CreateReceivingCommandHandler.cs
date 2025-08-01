using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockEntry;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Entities;
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
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Fornecedor", request.SupplierId), false);
            }

            receiving.Responsible = await _dbContext.Employees.FindAsync(request.ResponsibleId);
            if (receiving.Responsible == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Funcionário", request.SupplierId), false);
            }

            var account = await _dbContext.Users.FindAsync(request.AccountId);
            if (account == null)
            {
                return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, ApiMessages.NotFoundWithId("Conta", request.SupplierId), false);
            }

            decimal totalCalculatedValue = 0;
            var newReceivingItems = new List<ReceivingItem>();

            foreach (var itemCommand in request.ReceivingItems)
            {
                var product = await _dbContext.Products.FindAsync(itemCommand.ProductId);
                if (product == null)
                {
                    return new ApiResponse<ReceivingDto>(StatusCodes.Status404NotFound, $"{ApiMessages.NotFoundWithId("Produto", itemCommand.ProductId)} para o item.", false);
                }

                var receivingItem = _mapper.Map<ReceivingItem>(itemCommand);
                receivingItem.Product = product;
                receivingItem.TotalValue = receivingItem.Quantity * receivingItem.UnitValue;

                newReceivingItems.Add(receivingItem);
                totalCalculatedValue += receivingItem.TotalValue;
            }

            receiving.ReceivingItems = newReceivingItems;
            receiving.TotalValue = totalCalculatedValue;

            await _dbContext.Receivings.AddAsync(receiving, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Recebimento {ReceivingId} criado com sucesso. Agora gerando movimentos de estoque.", receiving.Id);

            foreach (var item in receiving.ReceivingItems)
            {
                var createStockEntryCommand = new CreateStockEntryCommand(
                    ProductId: item.ProductId,
                    Quantity: item.Quantity,
                    SourceDocumentId: receiving.Id,
                    SourceDocumentType: "Receiving",
                    ResponsibleId: receiving.ResponsibleId
                );
                await _mediator.Send(createStockEntryCommand, cancellationToken);
            }

            var receivingDto = _mapper.Map<ReceivingDto>(receiving);
            return new ApiResponse<ReceivingDto>(StatusCodes.Status201Created, ApiMessages.ReceivingAndStockMovementsCreatedSuccessfully, receivingDto);
        }
    }
}
