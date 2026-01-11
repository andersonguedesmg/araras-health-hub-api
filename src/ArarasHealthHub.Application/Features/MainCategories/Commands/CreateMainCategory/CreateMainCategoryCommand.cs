using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory
{
    public record CreateMainCategoryCommand(
        string Name
    ) : IRequest<ApiResponse<int>>;
}
