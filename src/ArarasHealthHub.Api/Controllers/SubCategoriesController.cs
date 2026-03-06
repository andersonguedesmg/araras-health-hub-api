using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.DeactivateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown;
using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/v1/subcategories")]
    [Authorize]
    public class SubCategoriesController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<SubCategoryListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSubCategoriesQuery query, CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<SubCategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return await Send(new GetSubCategoryByIdQuery(id), cancellationToken);
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(CreateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            return await SendCreated(
                command,
                nameof(GetById),
                id => new { id },
                cancellationToken);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(int id, UpdateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            return await Send(command.WithId(id), cancellationToken);
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Activate(int id, CancellationToken cancellationToken)
        {
            return await Send(new ActivateSubCategoryCommand(id), cancellationToken);
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Deactivate(int id, CancellationToken cancellationToken)
        {
            return await Send(new DeactivateSubCategoryCommand(id), cancellationToken);
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResult<DropdownItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDropdown([FromQuery] GetSubCategoryDropdownQuery query, CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }
    }
}
