using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.DeactivateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Application.Features.SubCategories.Queries.ExportSubCategories;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryDropdown;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/v1/subcategories")]
    [Authorize]
    public class SubCategoriesController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<SubCategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSubCategoriesQuery query)
        {
            return await Send(query);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<SubCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await Send(new GetSubCategoryByIdQuery(0).WithId(id));
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateSubCategoryCommand command)
        {
            return await Send(command);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateSubCategoryCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Activate(int id, ActivateSubCategoryCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate(int id, DeactivateSubCategoryCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResponse<DropdownItemDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdown([FromQuery] GetSubCategoryDropdownQuery query)
        {
            return await Send(query);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Export([FromQuery] ExportSubCategoriesQuery query)
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
