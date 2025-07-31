using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Shared.Core;
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
        List<CreateReceivingItemCommand> ReceivedItems
    ) : IRequest<ApiResponse<ReceivingDto>>;

    public record CreateReceivingItemCommand(
        int Quantity,
        decimal UnitValue,
        string Batch,
        DateTime ExpiryDate,
        int ProductId
    );
}
