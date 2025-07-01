using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
  [TestFixture]
  public class CalculatorTests
  {
    private SimpleCalculator calc;

    [SetUp]
    public void SetUp()
    {
      calc = new SimpleCalculator();
    }

    [TearDown]
    public void TearDown()
    {
      calc = null;
    }

    [Test]
    [TestCase(2, 3, 5)]
    [TestCase(-1, 1, 0)]
    [TestCase(100, 200, 300)]
    public void Addition_ReturnsCorrectSum(double a, double b, double expected)
    {
      var result = calc.Addition(a, b);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(5, 2, 3)]
    [TestCase(0, 1, -1)]
    public void Subtraction_ReturnsCorrectDifference(double a, double b, double expected)
    {
      var result = calc.Subtraction(a, b);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(2, 3, 6)]
    [TestCase(-1, -1, 1)]
    public void Multiplication_ReturnsCorrectProduct(double a, double b, double expected)
    {
      var result = calc.Multiplication(a, b);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(10, 2, 5)]
    [TestCase(7.5, 2.5, 3)]
    public void Division_ReturnsCorrectQuotient(double a, double b, double expected)
    {
      var result = calc.Division(a, b);
      Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Division_ByZero_ThrowsException()
    {
      Assert.Throws<ArgumentException>(() => calc.Division(10, 0));
    }
  }
}
