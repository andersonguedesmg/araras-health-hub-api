using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.Products.Commands.ActivateProduct;
using ArarasHealthHub.Application.Features.Products.Commands.CreateProduct;
using ArarasHealthHub.Application.Features.Products.Commands.DeactivateProduct;
using ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Products.Queries.ExportProducts;
using ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts;
using ArarasHealthHub.Application.Features.Products.Queries.GetProductById;
using ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdown;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    [Authorize]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQuery query)
        {
            return await Send(query);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await Send(new GetProductByIdQuery(0).WithId(id));
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return await Send(command);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Activate(int id, ActivateProductCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate(int id, DeactivateProductCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResponse<DropdownItemDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdown([FromQuery] GetProductDropdownQuery query)
        {
            return await Send(query);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Export([FromQuery] ExportProductsQuery query)
        {
            var response = await Mediator.Send(query);

            if (!response.Success || response.Data == null)
                return StatusCode(response.StatusCode, response);

            return File(
                response.Data.Content,
                response.Data.ContentType,
                response.Data.FileName
            );
        }
    }
}
