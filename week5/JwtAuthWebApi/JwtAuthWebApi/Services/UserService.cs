using System.Security.Cryptography;
using System.Text;
using JwtAuthWebApi.Models;

namespace JwtAuthWebApi.Services;

public interface IUserService
{
  User? Authenticate(string username, string password);
}

public class UserService : IUserService
{
  private readonly List<User> _users = new()
    {
        new User { Id = 1, Username = "admin", Password = HashPassword("password123"), Email = "admin@example.com" },
        new User { Id = 2, Username = "user", Password = HashPassword("userpass"), Email = "user@example.com" }
    };

  public User? Authenticate(string username, string password)
  {
    var user = _users.FirstOrDefault(u => u.Username == username);
    if (user == null) return null;

    return VerifyPassword(password, user.Password) ? user : null;
  }

  private static string HashPassword(string password)
  {
    using var sha256 = SHA256.Create();
    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "JwtAuthSalt"));
    return Convert.ToBase64String(hashedBytes);
  }

  private static bool VerifyPassword(string password, string hashedPassword)
  {
    var hashOfInput = HashPassword(password);
    return hashOfInput == hashedPassword;
  }
}
