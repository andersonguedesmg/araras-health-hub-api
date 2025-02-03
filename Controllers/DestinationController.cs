using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Destination;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
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
        [Authorize]
        public async Task<IActionResult> GetAllDestination()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinations = await _destinationRepo.GetAllAsync();

            var destinationsDto = destinations.Select(s => s.ToDestinationDto());

            return Ok(destinations);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetDestinationById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destination = await _destinationRepo.GetByIdAsync(id);

            if (destination == null)
            {
                return NotFound();
            }

            return Ok(destination.ToDestinationDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDestination([FromBody] CreateDestinationRequestDto destinationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = destinationDto.ToDestinationFromCreateDto();
            await _destinationRepo.CreateAsync(destinationModel);

            return CreatedAtAction(nameof(GetDestinationById), new { id = destinationModel.Id }, destinationModel.ToDestinationDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateDestination([FromRoute] int id, [FromBody] UpdateDestinationRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = await _destinationRepo.UpdateAsync(id, updateDto);

            if (destinationModel == null)
            {
                return NotFound();
            }

            return Ok(destinationModel.ToDestinationDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteDestination([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationModel = await _destinationRepo.DeleteAsync(id);

            if (destinationModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
