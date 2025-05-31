using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.AuthDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_Service.IService;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDto loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid login request.");
            }
            var response = await _userService.Login(loginRequest);
            if (response == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDto registerRequest)
        {
            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.Username) || string.IsNullOrEmpty(registerRequest.Password))
            {
                return BadRequest("Invalid registration request.");
            }
            await _userService.Register(registerRequest);
            return Ok("Register!!");
        }
    }
}
