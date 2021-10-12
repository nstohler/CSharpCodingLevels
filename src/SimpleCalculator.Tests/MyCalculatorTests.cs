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

        [TestMethod]
        [DataRow(2, 3, 8)]
        [DataRow(3, 2, 9)]
        [DataRow(4, 0, 0)]
        [DataRow(5, 1, 5)]
        public void PowerWithLoop_should_create_correct_result(int x, int y, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.PowerWithLoop(x, y);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(2, 3, 8)]
        [DataRow(3, 2, 9)]
        [DataRow(4, 0, 0)]
        [DataRow(5, 1, 5)]
        public void PowerWithMathPow_should_create_correct_result(int x, int y, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.PowerWithMathPow(x, y);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(12, 18, 6)]
        [DataRow(6, 4, 2)]
        [DataRow(4, 6, 2)]
        [DataRow(18, 48, 6)]
        [DataRow(36, 66, 6)]
        [DataRow(12, 27, 3)]
        public void GetGgt_should_create_correct_result(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.GetGgt(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(3, 5, 15)]
        [DataRow(20, 24, 120)]
        [DataRow(24, 20, 120)]
        [DataRow(4, 10, 20)]
        [DataRow(5, 7, 35)]
        [DataRow(15, 20, 60)]
        public void GetKgv_should_create_correct_result(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.GetKgv(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(3, 5, 15)]
        [DataRow(20, 24, 120)]
        [DataRow(24, 20, 120)]
        [DataRow(4, 10, 20)]
        [DataRow(5, 7, 35)]
        [DataRow(15, 20, 60)]
        public void GetKgvWithGgt_should_create_correct_result(int a, int b, int expectedResult)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.GetKgvWithGgt(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(2, 1, 2)]
        [DataRow(5, 1, 2, 3, 5, 8)]
        [DataRow(8, 1, 2, 3, 5, 8, 13, 21, 34)]
        public void GetFibonacciNumbers_should_create_correct_result(int count, params int[] expectedNumbers)
        {
            // Arrange
            var calculator = new MyCalculator();

            // Act
            var result = calculator.GetFibonacciNumbers(count);

            // Assert
            result.Should().BeEquivalentTo(expectedNumbers);
        }
    }
}
