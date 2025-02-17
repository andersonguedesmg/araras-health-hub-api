using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Destination;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Controllers
{
    [Route("api/destination")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationRepository _destinationRepo;

        public DestinationController(IDestinationRepository destinationRepo)
        {
            _destinationRepo = destinationRepo;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinations = await _destinationRepo.GetAllAsync();

            return Ok(new ApiResponse<List<Destination>>(StatusCodes.Status200OK, ApiMessages.MsgDestinationsFoundSuccessfully, destinations));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destination = await _destinationRepo.GetByIdAsync(id);

            if (destination == null)
            {
                return NotFound(new ApiResponse<Destination>(StatusCodes.Status404NotFound, ApiMessages.MsgDestinationNotFound, null!));
            }

            return Ok(new ApiResponse<Destination>(StatusCodes.Status200OK, ApiMessages.MsgDestinationFoundSuccessfully, destination));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateDestinationRequestDto destinationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = destinationDto.ToDestinationFromCreateDto();
            var newDestination = await _destinationRepo.CreateAsync(destinationModel);

            return CreatedAtAction(nameof(GetById), new { id = destinationModel.Id }, new ApiResponse<Destination>(StatusCodes.Status201Created, ApiMessages.MsgDestinationCreatedSuccessfully, newDestination));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDestinationRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = await _destinationRepo.UpdateAsync(id, updateDto);

            if (destinationModel == null)
            {
                return NotFound(new ApiResponse<Destination>(StatusCodes.Status404NotFound, ApiMessages.MsgDestinationNotFound, null!));

            }

            return Ok(new ApiResponse<Destination>(StatusCodes.Status200OK, ApiMessages.MsgDestinationUpdatedSuccessfully, destinationModel));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = await _destinationRepo.DeleteAsync(id);

            if (destinationModel == null)
            {
                return NotFound(new ApiResponse<Destination>(StatusCodes.Status404NotFound, ApiMessages.MsgDestinationNotFound, null!));
            }

            return Ok(new ApiResponse<Destination>(StatusCodes.Status200OK, ApiMessages.MsgDestinationDeletedSuccessfully, destinationModel));
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusDestinationRequestDto changeStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = await _destinationRepo.ChangeStatusAsync(id, changeStatusDto);

            if (destinationModel == null)
            {
                return NotFound(new ApiResponse<Destination>(StatusCodes.Status404NotFound, ApiMessages.MsgDestinationNotFound, null!));
            }

            return Ok(new ApiResponse<Destination>(StatusCodes.Status200OK, ApiMessages.MsgDestinationUpdatedSuccessfully, destinationModel));
        }
    }
}
