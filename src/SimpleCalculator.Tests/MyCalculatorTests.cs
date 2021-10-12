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

        [TestMethod]
        public void Calculator_add_should_create_correct_sum()
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Add(1, 2);

            // Assert
            result.Should().Be(3);
        }

        [TestMethod]
        [DataRow(2, 5, 7)]
        [DataRow(5, -10, -5)]
        public void Calculator_add_should_create_correct_sum(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Calculator_subtract_should_create_correct_result()
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Subtract(5, 3);

            // Assert
            result.Should().Be(2);
        }

        [TestMethod]
        [DataRow(10, 7, 3)]
        [DataRow(-5, 5, -10)]
        [DataRow(1, -5, 6)]
        public void Calculator_subtract_should_create_correct_result(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Subtract(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Calculator_multiply_should_create_correct_result()
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Multiply(3, 4);

            // Assert
            result.Should().Be(12);
        }

        [TestMethod]
        [DataRow(3, 7, 21)]
        [DataRow(7, 3, 21)]
        [DataRow(0, 0, 0)]
        [DataRow(1, 0, 0)]
        [DataRow(0, 1, 0)]
        [DataRow(3, -5, -15)]
        public void Calculator_multiply_should_create_correct_result(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Multiply(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Calculator_divide_should_create_correct_result()
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Multiply(15, 3);

            // Assert
            result.Should().Be(5);
        }

        [TestMethod]
        [DataRow(24, 8, 3)]
        [DataRow(12, 3, 4)]
        [DataRow(7, 1, 7)]
        [DataRow(0, 123, 0)]
        [DataRow(0, 1, 0)]
        [DataRow(-15, 3, -5)]
        [DataRow(15, -3, 5)]
        public void Calculator_divide_should_create_correct_result(int divident, int divisor, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.Multiply(divident, divisor);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
