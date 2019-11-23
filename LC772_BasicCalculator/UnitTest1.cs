using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC772_BasicCalculator
{
    [TestClass]
    public class BasicCalculatorTests
    {
        [TestMethod]
        public void GivenBasicExpressionString_Calculate_ShouldReturnCorrectResult()
        {
            var input = "1 + 1";

            var result = Calculate(input);

            Assert.IsTrue(result == 2);
        }

        private int Calculate(string input)
        {
            input.Replace(" ", "");
            return CalculateHelper(input);
        }

        private int CalculateHelper(string input)
        {
            var left = "";
            var right = "";
            var operatorIndex = -1;
            if (input.StartsWith("("))
            {
                var closing = FindCorrespondingClosing(input);
                left = input.Substring(1, closing - 1);
                input = closing == input.Length - 1 ? "" : input.Substring(closing + 1);
            }

            if (string.IsNullOrEmpty(input))
            {
                return Convert.ToInt32(left);
            }

            operatorIndex = FindFirstExpressionIndex(input);
            right = input.Substring(operatorIndex + 1);
            
            return CalculateBasicExpression(CalculateHelper(left), CalculateHelper(right), input[operatorIndex].ToString());
        }

        private int FindFirstExpressionIndex(string input)
        {
            throw new NotImplementedException();
        }

        private int FindCorrespondingClosing(string input)
        {
            throw new NotImplementedException();
        }

        private int CalculateBasicExpression(int left, int right, string operation)
        {
            switch (operation)
            {
                case "+":
                    return left + right;

                case "-":
                    return left - right;

                case "*":
                    return left * right;

                case "/":
                    return left / right;

                default:
                    throw new Exception();
            }
        }

        private class BasicExpression
        {
            public int left;
            public int right;
            public char operation;
        }
    }
}
