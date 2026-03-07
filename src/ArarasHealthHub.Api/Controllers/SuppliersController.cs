using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Application.Features.Suppliers.Commands.ActivateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdown;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/suppliers")]
    [Authorize]
    public class SuppliersController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<SupplierListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllSuppliersQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<SupplierResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(new GetSupplierByIdQuery(id), cancellationToken);
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(
            CreateSupplierCommand command,
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
            UpdateSupplierCommand command,
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
                new ActivateSupplierCommand(id),
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
                new DeactivateSupplierCommand(id),
                cancellationToken);
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResult<DropdownItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDropdown(
            [FromQuery] GetSupplierDropdownQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }
    }
}
