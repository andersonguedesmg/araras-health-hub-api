using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.ChangeStatusProduct
{
    public record ChangeStatusProductCommand(
        int Id,
        bool IsActive
    ) : IRequest<ApiResponse<bool>>;
}
