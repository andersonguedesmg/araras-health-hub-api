using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Inventory.Entries;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving
{
    public class CreateReceivingCommandHandler : IRequestHandler<CreateReceivingCommand, Result<int>>
    {
        private readonly IInventoryEntryService _inventoryEntryService;

        public CreateReceivingCommandHandler(
            IInventoryEntryService inventoryEntryService)
        {
            _inventoryEntryService = inventoryEntryService;
        }

        public async Task<Result<int>> Handle(
            CreateReceivingCommand request,
            CancellationToken cancellationToken)
        {
            return await _inventoryEntryService.CreateReceivingAsync(
                request,
                cancellationToken);
        }
    }
}
