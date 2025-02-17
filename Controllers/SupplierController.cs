using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
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
                return BadRequest(ModelState);

            var suppliers = await _supplierRepo.GetAllAsync();

            return Ok(new ApiResponse<List<Supplier>>(StatusCodes.Status200OK, ApiMessages.MsgSuppliersFoundSuccessfully, suppliers));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
                return BadRequest(ModelState);

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
                return BadRequest(ModelState);

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
                return BadRequest(ModelState);

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
                return BadRequest(ModelState);

            var supplierModel = await _supplierRepo.ChangeStatusAsync(id, changeStatusDto);

            if (supplierModel == null)
            {
                return NotFound(new ApiResponse<Supplier>(StatusCodes.Status404NotFound, ApiMessages.MsgSupplierNotFound, null!));
            }

            return Ok(new ApiResponse<Supplier>(StatusCodes.Status200OK, ApiMessages.MsgSupplierUpdatedSuccessfully, supplierModel));
        }
    }
}
