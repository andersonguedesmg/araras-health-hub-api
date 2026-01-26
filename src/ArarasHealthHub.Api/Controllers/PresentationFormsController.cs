using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Common;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.ChangeStatusPresentationForm;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.DeletePresentationForm;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Application.Features.PresentationForms.Queries.ExportPresentationForms;
using ArarasHealthHub.Application.Features.PresentationForms.Queries.GetAllPresentationForms;
using ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormById;
using ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormDropdown;
using ArarasHealthHub.Shared.Core.Pagination;
using ArarasHealthHub.Shared.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/v1/presentation-forms")]
    [Authorize]
    public class PresentationFormsController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<PresentationFormDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPresentationFormsQuery query)
        {
            return await Send(query);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<PresentationFormDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await Send(new GetPresentationFormByIdQuery(0).WithId(id));
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreatePresentationFormCommand command)
        {
            return await Send(command);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdatePresentationFormCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/status")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeStatus(int id, ChangeStatusPresentationFormCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return await Send(new DeletePresentationFormCommand(0).WithId(id));
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResponse<PresentationFormNameDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdown([FromQuery] GetPresentationFormDropdownQuery query)
        {
            return await Send(query);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Export([FromQuery] ExportPresentationFormsQuery query)
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
