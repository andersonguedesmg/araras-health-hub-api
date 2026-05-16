using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Costs;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Entries;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Lots;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Movements;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Services.Inventory.Entries
{
    public class InventoryEntryService : IInventoryEntryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IReceivingRepository _receivingRepository;
        private readonly IInventoryCostService _inventoryCostService;
        private readonly IInventoryMovementService _inventoryMovementService;
        private readonly IInventoryLotService _inventoryLotService;

        public InventoryEntryService(
            IApplicationDbContext dbContext,
            IReceivingRepository receivingRepository,
            IInventoryCostService inventoryCostService,
            IInventoryMovementService inventoryMovementService,
            IInventoryLotService inventoryLotService)
        {
            _dbContext = dbContext;
            _receivingRepository = receivingRepository;
            _inventoryCostService = inventoryCostService;
            _inventoryMovementService = inventoryMovementService;
            _inventoryLotService = inventoryLotService;
        }

        public async Task<Result<int>> CreateReceivingAsync(
            CreateReceivingCommand command,
            CancellationToken cancellationToken)
        {
            var supplier = await _dbContext.Suppliers
                .FindAsync([command.SupplierId], cancellationToken);

            if (supplier is null)
                throw new DomainException(
                    $"Fornecedor {command.SupplierId} não encontrado."
                );

            var responsible = await _dbContext.Employees
                .FindAsync([command.ResponsibleId], cancellationToken);

            if (responsible is null)
                throw new DomainException(
                    $"Funcionário {command.ResponsibleId} não encontrado."
                );

            var receiving = new Receiving(
                invoiceNumber: command.InvoiceNumber,
                supplyAuthorization: command.SupplyAuthorization,
                receivingDate: command.ReceivingDate,
                supplierId: command.SupplierId,
                responsibleId: command.ResponsibleId,
                accountId: command.AccountId,
                observation: command.Observation
            );

            foreach (var itemCommand in command.ReceivedItems)
            {
                var product = await _dbContext.Products
                    .FindAsync([itemCommand.ProductId], cancellationToken);

                if (product is null)
                    throw new DomainException(
                        $"Produto {itemCommand.ProductId} não encontrado."
                    );

                var receivedItem = new ReceivedItem(
                    productId: itemCommand.ProductId,
                    quantity: itemCommand.Quantity,
                    unitValue: itemCommand.UnitValue,
                    batch: itemCommand.Batch,
                    brand: itemCommand.Brand,
                    expiryDate: itemCommand.ExpiryDate
                );

                receiving.AddItem(receivedItem);

                await ProcessStockEntryAsync(
                    receiving,
                    receivedItem,
                    cancellationToken);
            }

            await _receivingRepository.AddAsync(
                receiving,
                cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(
                receiving.Id,
                "Recebimento criado com sucesso."
            );
        }

        private async Task ProcessStockEntryAsync(
            Receiving receiving,
            ReceivedItem item,
            CancellationToken cancellationToken)
        {
            var stock = await _dbContext.Stocks
                .Include(x => x.StockCost)
                .Include(x => x.Lots)
                .FirstOrDefaultAsync(
                    x => x.ProductId == item.ProductId,
                    cancellationToken);

            if (stock is null)
            {
                stock = new Stock(item.ProductId);

                await _dbContext.Stocks.AddAsync(
                    stock,
                    cancellationToken);
            }

            stock.IncreaseStock(item.Quantity);

            var stockLot = await _inventoryLotService.GetOrCreateLotAsync(
                    stock: stock,
                    batch: item.Batch,
                    brand: item.Brand,
                    unitValue: item.UnitValue,
                    expiryDate: item.ExpiryDate,
                    quantity: item.Quantity,
                    receivedItemId: item.Id,
                    cancellationToken: cancellationToken);

            _inventoryCostService.ProcessEntryCost(
                stock,
                item.Quantity,
                item.UnitValue);

            await _inventoryMovementService.CreateMovementAsync(
                    stockLot: stockLot,
                    quantity: item.Quantity,
                    direction: MovementDirectionEnum.Entry,
                    reason: MovementReasonEnum.Receiving,
                    movementDate: receiving.ReceivingDate,
                    sourceDocumentId: receiving.Id,
                    sourceDocumentType: nameof(Receiving),
                    responsibleId: receiving.ResponsibleId,
                    movementCost: item.TotalValue,
                    cancellationToken: cancellationToken);
        }
    }
}
