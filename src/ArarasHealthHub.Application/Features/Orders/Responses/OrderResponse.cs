using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Responses;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public sealed record OrderResponse(
        int Id,
        string? Observation,
        OrderStatusResponse Status,
        DropdownItemResponse Facility,

        DropdownItemResponse CreatedByEmployee,
        AccountMinimalDto CreatedByAccount,

        DropdownItemResponse? ApprovedByEmployee,
        AccountMinimalDto? ApprovedByAccount,

        DropdownItemResponse? SeparatedByEmployee,
        AccountMinimalDto? SeparatedByAccount,

        DropdownItemResponse? FinalizedByEmployee,
        AccountMinimalDto? FinalizedByAccount,

        DropdownItemResponse? CanceledByEmployee,
        AccountMinimalDto? CanceledByAccount,

        DateTime CreatedAt,
        DateTime? ApprovedAt,
        DateTime? SeparatedAt,
        DateTime? FinalizedAt,
        DateTime? CanceledAt,

        IReadOnlyCollection<OrderItemResponse> Items
    );
}
