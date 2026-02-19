using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

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
    ) : IRequest<ApiResponseO<ReceivingDto>>, ITransactionalRequest;

    public record CreateReceivedItemCommand(
        int Quantity,
        decimal UnitValue,
        string Batch,
        string Brand,
        DateTime ExpiryDate,
        int ProductId
    );
}
