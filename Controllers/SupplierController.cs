using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
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
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierRepo.GetAllAsync();

            var suppliersDto = suppliers.Select(s => s.ToSupplierDto());

            return Ok(suppliers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSupplierById([FromRoute] int id)
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
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRequestDto supplierDto)
        {
            var supplierModel = supplierDto.ToSupplierFromCreateDto();
            await _supplierRepo.CreateAsync(supplierModel);

            return CreatedAtAction(nameof(GetSupplierById), new { id = supplierModel.Id }, supplierModel.ToSupplierDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateSupplier([FromRoute] int id, [FromBody] UpdateSupplierRequestDto updateDto)
        {
            var supplierModel = await _supplierRepo.UpdateAsync(id, updateDto);

            if (supplierModel == null)
            {
                return NotFound();
            }

            return Ok(supplierModel.ToSupplierDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id)
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
    }
}
