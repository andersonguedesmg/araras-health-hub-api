using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories;
using ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory;
using ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory;
using ArarasHealthHub.Application.Features.MainCategories.Commands.ChangeStatusMainCategory;
using ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryDropdownOptions;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/product-metadata")]
    [ApiController]
    [Authorize]
    public class ProductsMetadataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsMetadataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAllMainCategories")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<MainCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllMainCategories([FromQuery] GetAllMainCategoriesQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("createMainCategory")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateMainCategory([FromBody] CreateMainCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("updateMainCategory/{id}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMainCategory([FromRoute] int id, [FromBody] UpdateMainCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.IdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("changeStatusMainCategory/{id}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeStatusMainCategory([FromRoute] int id, [FromBody] ChangeStatusMainCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.IdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getMainCategoryDropdownOptions")]
        [ProducesResponseType(typeof(ApiResponse<List<MainCategoryNameDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMainCategoryDropdownOptions()
        {
            var query = new GetMainCategoryDropdownOptionsQuery();
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
