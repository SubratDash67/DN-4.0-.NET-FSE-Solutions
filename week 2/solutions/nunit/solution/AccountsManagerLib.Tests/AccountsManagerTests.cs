using NUnit.Framework;
using AccountsManagerLib;
using System;

namespace AccountsManagerLib.Tests
{
  [TestFixture]
  public class AccountsManagerTests
  {
    private AccountsManager manager = null!;

    [SetUp]
    public void SetUp()
    {
      manager = new AccountsManager();
    }

    [TearDown]
    public void TearDown()
    {
      manager = null!;
    }

    [Test]
    [TestCase("user_11", "secret@user11", "Welcome user_11!!!")]
    [TestCase("user_22", "secret@user22", "Welcome user_22!!!")]
    public void ValidateUser_ValidCredentials_ReturnsWelcomeMessage(string userId, string password, string expectedMessage)
    {
      var result = manager.ValidateUser(userId, password);
      Assert.That(result, Is.EqualTo(expectedMessage));
    }

    [Test]
    [TestCase("user_11", "wrongpassword")]
    [TestCase("unknown_user", "secret@user11")]
    [TestCase("user_22", "wrongpass")]
    public void ValidateUser_InvalidCredentials_ReturnsInvalidMessage(string userId, string password)
    {
      var result = manager.ValidateUser(userId, password);
      Assert.That(result, Is.EqualTo("Invalid user id/password"));
    }

    [Test]
    [TestCase((string?)null, "password")]
    [TestCase("user_11", (string?)null)]
    [TestCase("", "")]
    public void ValidateUser_EmptyOrNullInputs_ThrowsFormatException(string? userId, string? password)
    {
      Assert.Throws<FormatException>(() => manager.ValidateUser(userId, password!));
    }
  }
}
