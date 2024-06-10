using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserApi.Interface;
using UserApi.Dtos;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> Authenticate(UserLoginDto userLoginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userLoginDto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
        {
            throw new InvalidCredentialsError();
        }

        var token = GenerateJWTToken(user);
        return token;
    }

    private string GenerateJWTToken(User user)
    {
        var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");

        var claims = new List<Claim> {
        new Claim("ID", user.Id.ToString()),
        new Claim("Username", user.UserName),
        new Claim("Role", user.Role.ToString()),
    };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: creds
            );
            
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
