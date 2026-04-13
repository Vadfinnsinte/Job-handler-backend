using JobHandlerAPI.Dtos;
using JobHandlerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHandlerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser( [FromBody] UserUpdateDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _userService.UpdateUserAsync(userId, dto);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);

        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _userService.ChangePasswordAsync(userId, dto);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _userService.DeleteUserAsync(userId);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(new { message = "User deleted successfully" });
        }
    }
}