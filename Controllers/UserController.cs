using araras_health_hub_api.Dtos.User;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<User>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var users = await _userRepo.GetAllAsync();

            if (users.Count == 0)
            {
                return NotFound(new ApiResponse<User>(StatusCodes.Status404NotFound, ApiMessages.MsgNotUsersFound, null!));
            }

            return Ok(new ApiResponse<List<User>>(StatusCodes.Status200OK, ApiMessages.MsgUsersFoundSuccessfully, users));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<User>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound(new ApiResponse<User>(StatusCodes.Status404NotFound, ApiMessages.MsgUserNotFound, null!));
            }

            return Ok(new ApiResponse<User>(StatusCodes.Status200OK, ApiMessages.MsgUserFoundSuccessfully, user));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<User>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var userModel = userDto.ToUserFromCreateDto();
            var newUser = await _userRepo.CreateAsync(userModel);

            return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, new ApiResponse<User>(StatusCodes.Status201Created, ApiMessages.MsgUserCreatedSuccessfully, newUser));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<User>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var userModel = await _userRepo.UpdateAsync(id, updateDto);

            if (userModel == null)
            {
                return NotFound(new ApiResponse<User>(StatusCodes.Status404NotFound, ApiMessages.MsgUserNotFound, null!));

            }

            return Ok(new ApiResponse<User>(StatusCodes.Status200OK, ApiMessages.MsgUserUpdatedSuccessfully, userModel));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<User>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var userModel = await _userRepo.DeleteAsync(id);

            if (userModel == null)
            {
                return NotFound(new ApiResponse<User>(StatusCodes.Status404NotFound, ApiMessages.MsgUserNotFound, null!));
            }

            return Ok(new ApiResponse<User>(StatusCodes.Status200OK, ApiMessages.MsgUserDeletedSuccessfully, userModel));
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusUserRequestDto changeStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<User>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var userModel = await _userRepo.ChangeStatusAsync(id, changeStatusDto);

            if (userModel == null)
            {
                return NotFound(new ApiResponse<User>(StatusCodes.Status404NotFound, ApiMessages.MsgUserNotFound, null!));
            }

            if (changeStatusDto.IsActive == true)
            {
                return Ok(new ApiResponse<User>(StatusCodes.Status200OK, ApiMessages.MsgUserActivatedSuccessfully, userModel));
            }

            return Ok(new ApiResponse<User>(StatusCodes.Status200OK, ApiMessages.MsgUserDisabledSuccessfully, userModel));
        }
    }
}
