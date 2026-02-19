using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder
{
    public record CancelOrderCommand : IRequest<ApiResponseO<bool>>, ITransactionalRequest
    {
        [Required]
        public int OrderId { get; init; }

        [Required]
        public int CanceledByAccountId { get; init; }

        [Required]
        public int CanceledByEmployeeId { get; init; }

        [Required]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A razão do cancelamento deve ter entre 10 e 500 caracteres.")]
        public string CancellationReason { get; init; } = string.Empty;
    }
}
