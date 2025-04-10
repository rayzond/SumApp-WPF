using NUnit.Framework;
using Calculator;

namespace SumApp.Calculator.Tests
{
    [TestFixture]
    public class CalculatorServiceTests
    {
        private CalculatorService _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new CalculatorService();
        }

        [Test]
        public void Add_WithValidNumbers_ReturnsCorrectSum()
        {
            // Act
            var result = _calculator.Add(5, 3);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [TestCase(0, 0, 0)]
        [TestCase(-5, 5, 0)]
        [TestCase(1.5, 2.5, 4)]
        [TestCase(100, 200, 300)]
        [TestCase(200, -400, -200)]
        public void Add_VariousInputs_ReturnsExpected(double a, double b, double expected)
        {
            var result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
