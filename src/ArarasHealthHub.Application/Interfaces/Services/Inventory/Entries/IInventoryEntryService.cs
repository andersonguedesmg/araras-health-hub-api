using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Inventory.Entries
{
    public interface IInventoryEntryService
    {
        Task<Result<int>> CreateReceivingAsync(
            CreateReceivingCommand command,
            CancellationToken cancellationToken);
    }
}
