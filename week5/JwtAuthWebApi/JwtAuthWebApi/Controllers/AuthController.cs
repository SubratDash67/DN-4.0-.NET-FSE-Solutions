using Microsoft.AspNetCore.Mvc;
using JwtAuthWebApi.Models;
using JwtAuthWebApi.Services;
using System.ComponentModel.DataAnnotations;

namespace JwtAuthWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IUserService _userService;
  private readonly IJwtService _jwtService;
  private readonly ILogger<AuthController> _logger;

  public AuthController(IUserService userService, IJwtService jwtService, ILogger<AuthController> logger)
  {
    _userService = userService;
    _jwtService = jwtService;
    _logger = logger;
  }

  [HttpPost("login")]
  public IActionResult Login([FromBody] LoginRequest request)
  {
    try
    {
      // Input validation
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
      {
        _logger.LogWarning("Login attempt with missing credentials");
        return BadRequest("Username and password are required");
      }

      var user = _userService.Authenticate(request.Username, request.Password);

      if (user == null)
      {
        _logger.LogWarning("Failed login attempt for username: {Username}", request.Username);
        return Unauthorized(new { message = "Invalid credentials" });
      }

      var token = _jwtService.GenerateToken(user);
      var expiration = _jwtService.GetTokenExpiration();

      var response = new LoginResponse
      {
        Token = token,
        Expiration = expiration
      };

      _logger.LogInformation("Successful login for user: {Username}", request.Username);
      return Ok(response);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error during login process");
      return StatusCode(500, new { message = "An error occurred during login" });
    }
  }
}
