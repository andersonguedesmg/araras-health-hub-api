using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/receiving")]
    [ApiController]
    public class ReceivingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceivingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<ReceivingDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ReceivingDto>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateReceivingCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<ReceivingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ReceivingDto>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetReceivingByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(PagedResponse<ReceivingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllReceivingsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
