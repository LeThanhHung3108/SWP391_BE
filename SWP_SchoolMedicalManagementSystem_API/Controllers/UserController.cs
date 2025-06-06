using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("get-user-by-id/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            return Ok(user);
        }

        [HttpGet("get-user-by-username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsernamelAsync(username);
            return Ok(user);
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Invalid update request.");
            }
            await _userService.UpdateUserAsync(id, request);
            return Ok("User updated successfully.");
        }

        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            await _userService.DeleteUserAsync(userId);
            return Ok("User deleted successfully.");
        }
    }
}
