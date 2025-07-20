using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Supplier.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepo;

        public SupplierController(ISupplierRepository supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Supplier>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var suppliers = await _supplierRepo.GetAllAsync();

            if (suppliers.Count == 0)
            {
                return NotFound(new ApiResponse<Supplier>(StatusCodes.Status404NotFound, ApiMessages.MsgNotSuppliersFound, null!));
            }

            return Ok(new ApiResponse<List<Supplier>>(StatusCodes.Status200OK, ApiMessages.MsgSuppliersFoundSuccessfully, suppliers));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Supplier>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var supplier = await _supplierRepo.GetByIdAsync(id);

            if (supplier == null)
            {
                return NotFound(new ApiResponse<Supplier>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, null!));
            }

            return Ok(new ApiResponse<Supplier>(StatusCodes.Status200OK, ApiMessages.MsgSupplierFoundSuccessfully, supplier));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequestDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Supplier>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var supplierModel = supplierDto.ToSupplierFromCreateDto();
            var newSupplier = await _supplierRepo.CreateAsync(supplierModel);

            return CreatedAtAction(nameof(GetById), new { id = supplierModel.Id }, new ApiResponse<Supplier>(StatusCodes.Status201Created, ApiMessages.MsgSupplierCreatedSuccessfully, newSupplier));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSupplierRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Supplier>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var supplierModel = await _supplierRepo.UpdateAsync(id, updateDto);

            if (supplierModel == null)
            {
                return NotFound(new ApiResponse<Supplier>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, null!));

            }

            return Ok(new ApiResponse<Supplier>(StatusCodes.Status200OK, ApiMessages.MsgSupplierUpdatedSuccessfully, supplierModel));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Supplier>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var supplierModel = await _supplierRepo.DeleteAsync(id);

            if (supplierModel == null)
            {
                return NotFound(new ApiResponse<Supplier>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, null!));
            }

            return Ok(new ApiResponse<Supplier>(StatusCodes.Status200OK, ApiMessages.MsgSupplierDeletedSuccessfully, supplierModel));
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusSupplierRequestDto changeStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Supplier>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var supplierModel = await _supplierRepo.ChangeStatusAsync(id, changeStatusDto);

            if (supplierModel == null)
            {
                return NotFound(new ApiResponse<Supplier>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, null!));
            }

            if (changeStatusDto.IsActive == true)
            {
                return Ok(new ApiResponse<Supplier>(StatusCodes.Status200OK, ApiMessages.MsgSupplierActivatedSuccessfully, supplierModel));
            }

            return Ok(new ApiResponse<Supplier>(StatusCodes.Status200OK, ApiMessages.MsgSupplierDisabledSuccessfully, supplierModel));
        }

        [HttpGet]
        [Route("getDropdownOptions")]
        [Authorize]
        public async Task<IActionResult> getDropdownOptions()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<SupplierNameDto>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var suppliers = await _supplierRepo.GetAllAsync();

            if (suppliers.Count == 0)
            {
                return NotFound(new ApiResponse<SupplierNameDto>(StatusCodes.Status404NotFound, ApiMessages.MsgNotSuppliersFound, null!));
            }

            var supplierNames = suppliers.Select(d => new SupplierNameDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            return Ok(new ApiResponse<List<SupplierNameDto>>(StatusCodes.Status200OK, ApiMessages.MsgSuppliersFoundSuccessfully, supplierNames));
        }
    }
}
