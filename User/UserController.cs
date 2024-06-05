using Microsoft.AspNetCore.Mvc;
using UserApi.DTOs;
using UserApi.Services;


namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var newUser = _userService.CreateUser(userCreateDto);
            return Ok(newUser);
        }
    }
}

