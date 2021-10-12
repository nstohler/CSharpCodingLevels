using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class MyCalculatorTests
    {
        [TestMethod]
        public void SetCalculatorName_sets_calculator_name_and_GetCalculatorName_gets_name()
        {
            // Arrange
            var name = "The ultimate calculator ⚡";
            var calculator = new MyCalculator();
            calculator.GetCalculatorName().Should().NotBe(name);

            // Act
            calculator.SetCalculatorName(name);

            // Assert
            calculator.GetCalculatorName().Should().Be(name);
        }
    }
}
