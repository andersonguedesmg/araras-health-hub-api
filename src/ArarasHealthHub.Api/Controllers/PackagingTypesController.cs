using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.PackagingTypes.Commands.ActivatePackagingType;
using ArarasHealthHub.Application.Features.PackagingTypes.Commands.CreatePackagingType;
using ArarasHealthHub.Application.Features.PackagingTypes.Commands.DeactivatePackagingType;
using ArarasHealthHub.Application.Features.PackagingTypes.Commands.UpdatePackagingType;
using ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetAllPackagingTypes;
using ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetPackagingTypeById;
using ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetPackagingTypeDropdown;
using ArarasHealthHub.Application.Features.PackagingTypes.Responses;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/v1/packaging-types")]
    [Authorize]
    public class PackagingTypesController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<PackagingTypeListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllPackagingTypesQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<PackagingTypeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(new GetPackagingTypeByIdQuery(id), cancellationToken);
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(
            CreatePackagingTypeCommand command,
            CancellationToken cancellationToken)
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
        public async Task<IActionResult> Update(
            int id,
            UpdatePackagingTypeCommand command,
            CancellationToken cancellationToken)
        {
            return await Send(
                command.WithId(id),
                cancellationToken);
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Activate(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(
                new ActivatePackagingTypeCommand(id),
                cancellationToken);
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Deactivate(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(
                new DeactivatePackagingTypeCommand(id),
                cancellationToken);
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResult<DropdownItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDropdown(
            [FromQuery] GetPackagingTypeDropdownQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }
    }
}
