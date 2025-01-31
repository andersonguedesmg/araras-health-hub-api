using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.DestinationUser;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    public class DestinationUserController : ControllerBase
    {
        private readonly IDestinationUserRepository _destinationUserRepo;
        private readonly IDestinationRepository _destinationRepo;

        public DestinationUserController(IDestinationUserRepository destinationUserRepo, IDestinationRepository destinationRepo)
        {
            _destinationUserRepo = destinationUserRepo;
            _destinationRepo = destinationRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDestinationUser()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationsUser = await _destinationUserRepo.GetAllAsync();

            var destinationsUserDto = destinationsUser.Select(s => s.ToDestinationUserDto());

            return Ok(destinationsUser);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDestinationUserById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationUser = await _destinationUserRepo.GetByIdAsync(id);

            if (destinationUser == null)
            {
                return NotFound();
            }

            return Ok(destinationUser.ToDestinationUserDto());
        }

        [HttpPost("{destinationId:int}")]
        public async Task<IActionResult> CreateDestinationUser([FromRoute] int destinationId, CreateDestinationUserRequestDto destinationUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _destinationRepo.DestinationExists(destinationId))
            {
                return BadRequest("O Destino não existe");
            }

            var destinationUserModel = destinationUserDto.ToDestinationUserFromCreateDto(destinationId);
            await _destinationUserRepo.CreateAsync(destinationUserModel);

            return CreatedAtAction(nameof(GetDestinationUserById), new { id = destinationUserModel.Id }, destinationUserModel.ToDestinationUserDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDestinationUser([FromRoute] int id, [FromBody] UpdateDestinationUserRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var destinationUserModel = await _destinationUserRepo.UpdateAsync(id, updateDto.ToDestinationUserFromUpdate());

            if (destinationUserModel == null)
            {
                return NotFound("Cliente não Encontrado");
            }

            return Ok(destinationUserModel.ToDestinationUserDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDestinationUse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commentModel = await _destinationUserRepo.DeleteAsync(id);

            if (commentModel == null)
            {
                return NotFound("Cliente não Existe");
            }

            return Ok(commentModel);
        }
    }
}
