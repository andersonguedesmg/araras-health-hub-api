using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateDispenseReturn
{
    public class CreateDispenseReturnCommand : IRequest<ApiResponseO<int>>, ITransactionalRequest
    {
        [Required]
        public int OriginalOrderId { get; init; }

        [Required]
        public int ReturnedByEmployeeId { get; init; }

        [Required]
        public int ReturnedByAccountId { get; init; }

        [Required]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A razão do retorno deve ter entre 10 e 500 caracteres.")]
        public string Reason { get; init; } = string.Empty;

        [Required]
        public List<DispenseReturnItemCommand> ReturnItems { get; init; } = new();
    }

    public record DispenseReturnItemCommand(
        [Required] int ProductId,
        [Required] decimal Quantity,
        [Required, StringLength(50)] string Batch,
        [StringLength(50)] string Brand,
        [Required] DateTime ExpiryDate,
        [Required] decimal UnitValue
    );
}
