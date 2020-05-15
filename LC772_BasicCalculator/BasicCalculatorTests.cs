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

        [TestMethod]
        public void GivenAnotherBasicExpressionString_Calculate_ShouldReturnCorrectResult()
        {
            var input = "2*(1+1)";

            var result = Calculate(input);

            Assert.IsTrue(result == 4);
        }

        private int Calculate(string input)
        {
            return CalculateHelper(input.Replace(" ", ""));
        }

        private int CalculateHelper(string input)
        {
            var left = "";
            var right = "";
            var operatorIndex = -1;
            var rightIndex = 0;
            if (input.StartsWith("("))
            {
                var closing = FindCorrespondingClosing(input);

                if (closing == -1)
                {
                    throw new Exception("should not happen");
                }

                left = input.Substring(1, closing - 1);
                rightIndex = closing + 1;
            }
            else
            {
                operatorIndex = FindFirstOperatorIndex(input, 0);

                left = input.Substring(0, operatorIndex);

                rightIndex = operatorIndex;
            }

            if (rightIndex >= input.Length)
            {
                return Convert.ToInt32(left);
            }

            operatorIndex = FindFirstOperatorIndex(input, rightIndex);

            right = input.Substring(operatorIndex + 1);
            
            return CalculateBasicExpression(CalculateHelper(left), CalculateHelper(right), input[operatorIndex].ToString());
        }

        private int FindFirstOperatorIndex(string input, int startIndex)
        {
            for (int i = startIndex; i < input.Length; i++)
            {
                var c = input[i];
                if (c == '*' || c == '/' || c == '-' || c == '+')
                {
                    return i;
                }
            }

            return input.Length;
        }

        private int FindCorrespondingClosing(string input)
        {
            var stack = new Stack<char>();
            stack.Push(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    return i;
                }
            }

            return -1;
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
