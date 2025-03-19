using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Product;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Product>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var products = await _productRepo.GetAllAsync();

            if (products.Count == 0)
            {
                return NotFound(new ApiResponse<Product>(StatusCodes.Status404NotFound, ApiMessages.MsgNotProductsFound, null!));
            }

            return Ok(new ApiResponse<List<Product>>(StatusCodes.Status200OK, ApiMessages.MsgProductsFoundSuccessfully, products));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Product>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var product = await _productRepo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound(new ApiResponse<Product>(StatusCodes.Status404NotFound, ApiMessages.MsgProductNotFound, null!));
            }

            return Ok(new ApiResponse<Product>(StatusCodes.Status200OK, ApiMessages.MsgProductFoundSuccessfully, product));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Product>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var productModel = productDto.ToProductFromCreateDto();
            var newProduct = await _productRepo.CreateAsync(productModel);

            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, new ApiResponse<Product>(StatusCodes.Status201Created, ApiMessages.MsgProductCreatedSuccessfully, newProduct));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Product>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var productModel = await _productRepo.UpdateAsync(id, updateDto);

            if (productModel == null)
            {
                return NotFound(new ApiResponse<Product>(StatusCodes.Status404NotFound, ApiMessages.MsgProductNotFound, null!));

            }

            return Ok(new ApiResponse<Product>(StatusCodes.Status200OK, ApiMessages.MsgProductUpdatedSuccessfully, productModel));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Product>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var productModel = await _productRepo.DeleteAsync(id);

            if (productModel == null)
            {
                return NotFound(new ApiResponse<Product>(StatusCodes.Status404NotFound, ApiMessages.MsgProductNotFound, null!));
            }

            return Ok(new ApiResponse<Product>(StatusCodes.Status200OK, ApiMessages.MsgProductDeletedSuccessfully, productModel));
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusProductRequestDto changeStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Product>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var productModel = await _productRepo.ChangeStatusAsync(id, changeStatusDto);

            if (productModel == null)
            {
                return NotFound(new ApiResponse<Product>(StatusCodes.Status404NotFound, ApiMessages.MsgProductNotFound, null!));
            }

            if (changeStatusDto.IsActive == true)
            {
                return Ok(new ApiResponse<Product>(StatusCodes.Status200OK, ApiMessages.MsgProductActivatedSuccessfully, productModel));
            }

            return Ok(new ApiResponse<Product>(StatusCodes.Status200OK, ApiMessages.MsgProductDisabledSuccessfully, productModel));
        }
    }
}
