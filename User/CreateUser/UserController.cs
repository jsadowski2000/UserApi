using Microsoft.AspNetCore.Mvc;
using UserApi.DTOs;
using UserApi.Services;
using System.Security.Claims;


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

        [HttpPatch("update-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Unauthorized();
        }

        try
        {
            await _userService.UpdatePassword(userId, updatePasswordDto);
            return Ok(new { Message = "Password updated successfully" });
        }
        
        catch 
        {
            return BadRequest(new { Message = "Incorrect password" });
        }

    }
}
}

