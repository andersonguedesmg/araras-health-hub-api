using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Facility;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Controllers
{
    [Route("api/facility")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository _facilityRepo;

        public FacilityController(IFacilityRepository facilityRepo)
        {
            _facilityRepo = facilityRepo;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Facility>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facilities = await _facilityRepo.GetAllAsync();

            if (facilities.Count == 0)
            {
                return NotFound(new ApiResponse<Facility>(StatusCodes.Status404NotFound, ApiMessages.MsgNotFacilitiesFound, null!));
            }

            return Ok(new ApiResponse<List<Facility>>(StatusCodes.Status200OK, ApiMessages.MsgFacilitiesFoundSuccessfully, facilities));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Facility>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facility = await _facilityRepo.GetByIdAsync(id);

            if (facility == null)
            {
                return NotFound(new ApiResponse<Facility>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, null!));
            }

            return Ok(new ApiResponse<Facility>(StatusCodes.Status200OK, ApiMessages.MsgFacilityFoundSuccessfully, facility));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateFacilityRequestDto facilityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Facility>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facilityModel = facilityDto.ToFacilityFromCreateDto();
            var newFacility = await _facilityRepo.CreateAsync(facilityModel);

            return CreatedAtAction(nameof(GetById), new { id = facilityModel.Id }, new ApiResponse<Facility>(StatusCodes.Status201Created, ApiMessages.MsgFacilityCreatedSuccessfully, newFacility));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFacilityRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Facility>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facilityModel = await _facilityRepo.UpdateAsync(id, updateDto);

            if (facilityModel == null)
            {
                return NotFound(new ApiResponse<Facility>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, null!));

            }

            return Ok(new ApiResponse<Facility>(StatusCodes.Status200OK, ApiMessages.MsgFacilityUpdatedSuccessfully, facilityModel));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Facility>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facilityModel = await _facilityRepo.DeleteAsync(id);

            if (facilityModel == null)
            {
                return NotFound(new ApiResponse<Facility>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, null!));
            }

            return Ok(new ApiResponse<Facility>(StatusCodes.Status200OK, ApiMessages.MsgFacilityDeletedSuccessfully, facilityModel));
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusFacilityRequestDto changeStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Facility>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facilityModel = await _facilityRepo.ChangeStatusAsync(id, changeStatusDto);

            if (facilityModel == null)
            {
                return NotFound(new ApiResponse<Facility>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, null!));
            }

            if (changeStatusDto.IsActive == true)
            {
                return Ok(new ApiResponse<Facility>(StatusCodes.Status200OK, ApiMessages.MsgFacilityActivatedSuccessfully, facilityModel));
            }

            return Ok(new ApiResponse<Facility>(StatusCodes.Status200OK, ApiMessages.MsgFacilityDisabledSuccessfully, facilityModel));
        }

        [HttpGet]
        [Route("getNames")]
        [Authorize]
        public async Task<IActionResult> GetNames()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<FacilityNameDto>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var facilities = await _facilityRepo.GetAllAsync();

            if (facilities.Count == 0)
            {
                return NotFound(new ApiResponse<FacilityNameDto>(StatusCodes.Status404NotFound, ApiMessages.MsgNotFacilitiesFound, null!));
            }

            var facilityNames = facilities.Select(d => new FacilityNameDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            return Ok(new ApiResponse<List<FacilityNameDto>>(StatusCodes.Status200OK, ApiMessages.MsgFacilitiesFoundSuccessfully, facilityNames));
        }
    }
}
