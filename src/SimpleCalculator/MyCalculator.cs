using System;

namespace SimpleCalculator
{
    public class MyCalculator
    {
        private string CalculatorName;

        public MyCalculator(string name = "")
        {
            CalculatorName = name;
        }

        public void SetCalculatorName(string name)
        {
            CalculatorName = name;
        }

        public string GetCalculatorName()
        {
            return CalculatorName;
        }

        /// <summary>
        /// Calculates the sum of two numbers
        /// </summary>
        public int Add(int a, int b)
        {
            // example: 1 + 2 = 3
            throw new NotImplementedException("This should return the sum of a and b.");
        }

        /// <summary>
        /// Subtracts a number (b) from another one (a)
        /// </summary>
        public int Subtract(int a, int b)
        {
            // example: 3 - 2 = 1
            throw new NotImplementedException("This should subtract b from a and return the result.");
        }

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        public int Multiply(int a, int b)
        {
            throw new NotImplementedException("This should multiply a and b and return the result.");
        }

        /// <summary>
        /// Computes the result of a division "dividend/divisor"
        /// </summary>
        public int Divide(int dividend, int divisor)
        {
            throw new NotImplementedException("This should divide the dividend by the divisor and return the result.");
        }

        /// <summary>
        /// Calculates x^y
        /// </summary>
        public int PowerWithLoop(int x, int y)
        {
            // Hints:
            // - use a for loop
            throw new NotImplementedException("This should raise x to the power of y (x^y) and return the result.");
        }

        /// <summary>
        /// Calculates x^y
        /// </summary>
        public int PowerWithMathPow(int x, int y)
        {
            // Hints:
            // - do NOT use any loop here
            // - use Math.Pow()
            // - convert the result from Math.Pow() to an integer (int), use "var intResult = (int)result;"
            throw new NotImplementedException("This should raise x to the power of y (x^y) and return the result.");
        }


    }
}
