using Microsoft.AspNetCore.Mvc;
using UserApi.Dtos;
using UserApi.Interface;


namespace UserApi.Controllers{

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        if (userLoginDto == null)
        {
            return BadRequest("Invalid client request");
        }

        var token = await _authService.Authenticate(userLoginDto);

        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(new { Token = token });
    }


}
}
