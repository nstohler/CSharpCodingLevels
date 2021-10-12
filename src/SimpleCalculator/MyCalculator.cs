using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Berechnet den ggT (grössten gemeinsamen Teiler).
        /// English: calculates the greatest common divisor GCD.
        /// </summary>
        public int GetGgt(int a, int b)
        {
            // https://www.gut-erklaert.de/mathematik/ggt-groesster-gemeinsamer-teiler.html

            // https://www.sofatutor.ch/mathematik/zahlen-rechnen-und-groessen/teilbarkeit-und-mengen/ggt-und-kgv
            // - Zuerst wird die grössere Zahl durch die kleinere Zahl geteilt.
            // - Dann wird die kleinere Zahl immer durch den Rest geteilt. Dies wird so lange wiederholt, bis der Rest 0 ist.
            // 
            //   360:105 = 3, der Rest ist 45, dann
            //   105:45 = 2, der Rest ist 15 und
            //   45:15 = 3, der Rest ist schließlich 0
            //   ggT(105,360)= 15

            throw new NotImplementedException("This should calculate the ggT and return the result.");
        }

        /// <summary>
        /// Calculate the KgV (Kleinstes gemeinsamer Vielfache) 
        /// English: calculates the least common multiple LCM.
        /// </summary>
        public int GetKgv(int a, int b)
        {
            // https://www.gut-erklaert.de/mathematik/kgv-kleinstes-gemeinsames-vielfaches.html

            throw new NotImplementedException("This should calculate the KgV and return the result.");
        }

        /// <summary>
        /// Calculate the KgV (Kleinstes gemeinsamer Vielfache) 
        /// English: calculates the least common multiple LCM.
        /// </summary>
        public int GetKgvWithGgt(int a, int b)
        {
            // Formel: ggT(a,b) * kgV(a,b) = a * b 
            // => kgV(a,b) = a * b / ggT(a,b)

            throw new NotImplementedException("This should calculate the KgV using the ggT and return the result.");
        }

        /// <summary>
        /// Returns a list with the first "count" Fibonacci numbers. 
        /// </summary>
        public List<int> GetFibonacciNumbers(int count)
        {
            // Fibonacci numbers: 1, 2, 3, 5, 8, 13, 21, 34, ...

            var fibonacciNumbers = new List<int>();

            // fibonacciNumbers.Add(number);

            throw new NotImplementedException("This should calculate the Fibonacci numbers using the ggT and return the results as a list.");

            return fibonacciNumbers;
        }
    }
}
