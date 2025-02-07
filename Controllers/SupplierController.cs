using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
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

            var suppliersDto = suppliers.Select(s => s.ToSupplierDto());

            return Ok(suppliers);
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
                return NotFound();
            }

            return Ok(supplier.ToSupplierDto());
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequestDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplierModel = supplierDto.ToSupplierFromCreateDto();
            await _supplierRepo.CreateAsync(supplierModel);

            return CreatedAtAction(nameof(GetById), new { id = supplierModel.Id }, supplierModel.ToSupplierDto());
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
                return NotFound();
            }

            return Ok(supplierModel.ToSupplierDto());
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
                return NotFound();
            }

            return NoContent();
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
                return NotFound();
            }

            return Ok(supplierModel.ToSupplierDto());
        }
    }
}
