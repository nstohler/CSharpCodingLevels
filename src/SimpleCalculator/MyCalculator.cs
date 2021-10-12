using System;

namespace SimpleCalculator
{
    public class MyCalculator
    {
        private string CalculatorName;

        public void SetCalculatorName(string name)
        {
            CalculatorName = name;
        }

        public string GetCalculatorName()
        {
            return CalculatorName;
        }
    }
}
