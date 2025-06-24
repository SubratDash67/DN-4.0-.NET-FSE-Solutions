using NUnit.Framework;
using Moq;
using MagicFilesLib;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
  [TestFixture]
  public class DirectoryExplorerTests
  {
    private Mock<IDirectoryExplorer> _mockDirectoryExplorer;
    private readonly string _file1 = "file.txt";
    private readonly string _file2 = "file2.txt";

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      _mockDirectoryExplorer = new Mock<IDirectoryExplorer>();
    }

    [TestCase]
    public void GetFiles_ShouldReturnMockedFiles()
    {
      var mockFiles = new List<string> { _file1, _file2 };
      _mockDirectoryExplorer.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(mockFiles);

      var result = _mockDirectoryExplorer.Object.GetFiles("any_path");

      Assert.That(result, Is.Not.Null);
      Assert.That(result.Count, Is.EqualTo(2));
      Assert.That(result, Contains.Item(_file1));
    }
  }
}