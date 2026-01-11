using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory
{
    public record UpdateMainCategoryCommand(
        int Id,
        string Name
    ) : IRequest<ApiResponse<bool>>;
}
