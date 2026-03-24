using LoanAdvisor.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto login)
    {
        // Dummy user check
        if (login.Username == "admin" && login.Password == "1234")
        {
            var token = GenerateToken(login.Username);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    private string GenerateToken(string username)
    {
        var jwtSettings = _config.GetSection("Jwt");

        var keyString = jwtSettings["Key"];
        if (string.IsNullOrEmpty(keyString))
        {
            throw new Exception("JWT Key is missing in appsettings.json");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, username)
    };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}