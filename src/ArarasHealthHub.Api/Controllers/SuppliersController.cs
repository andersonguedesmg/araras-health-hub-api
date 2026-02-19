using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.Suppliers.Commands.ActivateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.DeactivateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Features.Suppliers.Queries.ExportSuppliers;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdown;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;

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
        [ProducesResponseType(typeof(PagedResponse<SupplierDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSuppliersQuery query)
        {
            return await Send(query);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<SupplierDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await Send(new GetSupplierByIdQuery(0).WithId(id));
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateSupplierCommand command)
        {
            return await Send(command);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateSupplierCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Activate(int id, ActivateSupplierCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate(int id, DeactivateSupplierCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResponse<DropdownItemDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdown([FromQuery] GetSupplierDropdownQuery query)
        {
            return await Send(query);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Export([FromQuery] ExportSuppliersQuery query)
        {
            var response = await Mediator.Send(query);

            if (!response.Success || response.Data == null)
                return StatusCode(response.StatusCode, response);

            return File(
                response.Data.Content,
                response.Data.ContentType,
                response.Data.FileName
            );
        }
    }
}
