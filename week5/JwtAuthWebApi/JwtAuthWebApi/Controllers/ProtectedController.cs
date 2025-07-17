using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtAuthWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProtectedController : ControllerBase
{
  private readonly ILogger<ProtectedController> _logger;

  public ProtectedController(ILogger<ProtectedController> logger)
  {
    _logger = logger;
  }

  [HttpGet("profile")]
  public IActionResult GetProfile()
  {
    try
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var username = User.FindFirst(ClaimTypes.Name)?.Value;
      var email = User.FindFirst(ClaimTypes.Email)?.Value;

      if (string.IsNullOrEmpty(userId))
      {
        _logger.LogWarning("User ID claim not found in token");
        return BadRequest("Invalid token claims");
      }

      _logger.LogInformation("Profile accessed by user: {Username}", username);

      return Ok(new
      {
        UserId = userId,
        Username = username,
        Email = email,
        Message = "This is a protected endpoint",
        AccessTime = DateTime.UtcNow
      });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error retrieving user profile");
      return StatusCode(500, new { message = "An error occurred while retrieving profile" });
    }
  }

  [HttpGet("data")]
  public IActionResult GetSecureData()
  {
    try
    {
      var username = User.FindFirst(ClaimTypes.Name)?.Value;
      _logger.LogInformation("Secure data accessed by user: {Username}", username);

      return Ok(new
      {
        Data = "This is secure data that requires authentication",
        Timestamp = DateTime.UtcNow,
        User = username
      });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error retrieving secure data");
      return StatusCode(500, new { message = "An error occurred while retrieving data" });
    }
  }

  [HttpGet("admin")]
  [Authorize] // Can be extended with role-based authorization
  public IActionResult GetAdminData()
  {
    try
    {
      var username = User.FindFirst(ClaimTypes.Name)?.Value;

      // Simple admin check (can be improved with role-based authorization)
      if (username != "admin")
      {
        _logger.LogWarning("Non-admin user {Username} attempted to access admin endpoint", username);
        return Forbid("Admin access required");
      }

      _logger.LogInformation("Admin data accessed by: {Username}", username);

      return Ok(new
      {
        Data = "This is admin-only data",
        Timestamp = DateTime.UtcNow,
        AdminUser = username
      });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error retrieving admin data");
      return StatusCode(500, new { message = "An error occurred while retrieving admin data" });
    }
  }
}
