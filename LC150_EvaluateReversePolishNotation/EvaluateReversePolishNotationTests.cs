using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC150_EvaluateReversePolishNotation
{
    [TestClass]
    public class EvaluateReversePolishNotationTests
    {
        [TestMethod]
        public void GivenExpressionArray_Evaluate_ShouldReturnCorrectResult()
        {
            var expression = new string[] { "2", "1", "+", "3", "*" };

            var result = EvaluateExpression(expression);

            Assert.IsTrue(result == 9);
        }

        private int EvaluateExpression(string[] expression)
        {
            var numberStack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression[i]))
                {
                    EvaluateExpressionHelper(numberStack, expression[i]);
                }
                else
                {
                    numberStack.Push(Convert.ToInt32(expression[i]));
                }
            }

            return numberStack.Peek();

        }

        private void EvaluateExpressionHelper(Stack<int> numberStack, string operation)
        {
            var value1 = numberStack.Pop();
            var value2 = numberStack.Pop();

            switch (operation)
            {
                case "+":
                    numberStack.Push(value1 + value2);
                    break;
                case "-":
                    numberStack.Push(value1 - value2);
                    break;
                case "*":
                    numberStack.Push(value1 * value2);
                    break;
                case "/":
                    numberStack.Push(value1 / value2);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private bool IsOperator(string value)
        {
            return value == "+" || value == "*" || value == "-" || value == "/";
        }
    }
}
