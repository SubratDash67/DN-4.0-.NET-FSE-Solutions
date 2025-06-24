using NUnit.Framework;
using Moq;
using PlayersManagerLib;
using System;

namespace PlayerManager.Tests
{
  [TestFixture]
  public class PlayerTests
  {
    private Mock<IPlayerMapper> _mockPlayerMapper;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      _mockPlayerMapper = new Mock<IPlayerMapper>();
    }

    [TestCase]
    public void RegisterNewPlayer_ValidName_ShouldReturnPlayer()
    {
      _mockPlayerMapper.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);

      var player = Player.RegisterNewPlayer("John Doe", _mockPlayerMapper.Object);

      Assert.That(player, Is.Not.Null);
      Assert.That(player.Name, Is.EqualTo("John Doe"));
      Assert.That(player.Age, Is.EqualTo(23));
      Assert.That(player.Country, Is.EqualTo("India"));
      Assert.That(player.NoOfMatches, Is.EqualTo(30));
    }

    [TestCase]
    public void RegisterNewPlayer_EmptyName_ShouldThrowException()
    {
      Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer("", _mockPlayerMapper.Object));
    }

    [TestCase]
    public void RegisterNewPlayer_ExistingName_ShouldThrowException()
    {
      _mockPlayerMapper.Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(true);

      Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer("Existing Player", _mockPlayerMapper.Object));
    }
  }
}