using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Commands.ChangeStatusSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.DeleteSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdownOptions;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAll")]
        // [Authorize]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mediator.Send(new GetAllSuppliersQuery());

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        // [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetSupplierByIdQuery(id));

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [Route("create")]
        // [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        // [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSupplierCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.MsgIdMismatch, false));
            }

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        // [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteSupplierCommand(id));

            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        // [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusSupplierCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.MsgIdMismatch, false));
            }

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [Route("getDropdownOptions")]
        // [Authorize]
        public async Task<IActionResult> GetDropdownOptions()
        {
            var result = await _mediator.Send(new GetSupplierDropdownOptionsQuery());

            return StatusCode(result.StatusCode, result);
        }
    }
}
