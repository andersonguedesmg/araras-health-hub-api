using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving
{
    public record CreateReceivingCommand(
        string InvoiceNumber,
        string SupplyAuthorization,
        string? Observation,
        DateTime ReceivingDate,
        int SupplierId,
        int ResponsibleId,
        int AccountId,
        List<CreateReceivedItemCommand> ReceivedItems
    ) : IRequest<Result<int>>, ITransactionalRequest;

    public record CreateReceivedItemCommand(
        decimal Quantity,
        decimal UnitValue,
        string Batch,
        string Brand,
        DateTime ExpiryDate,
        int ProductId
    );
}
