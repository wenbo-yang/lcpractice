using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC32_LongestValidParentheses
{
    [TestClass]
    public class LongestValidParenthesesTests
    {
        // use stack, track index of unmatched index similar to LC20 valid parentheses,
        // similar to back trace, 
        // if stack is empty, then the whole string is valid, 
        // if not, compare indices in stack. and in the end.
        [TestMethod]
        public void GivenParenthesesWithAllValidEntry_GetLongest_ShouldReturnLengthOfString()
        {
            var input = "(()()())";

            int length = GetLongestValidParenthesesLength(input);

            Assert.IsTrue(length == input.Length);
        }

        [TestMethod]
        public void GivenParenthesesInValidFirst_GetLongest_ShouldReturnCorrectLength()
        {
            var input = ")()()()";

            int length = GetLongestValidParenthesesLength(input);

            Assert.IsTrue(length == 6);
        }

        [TestMethod]
        public void GivenParenthesesInValidFirstAndLast_GetLongest_ShouldReturnCorrectLength()
        {
            var input = ")()())";

            int length = GetLongestValidParenthesesLength(input);

            Assert.IsTrue(length == 4);
        }


        [TestMethod]
        public void GivenParenthesesValidHeadAndTail_GetLongest_ShouldReturnCorrectLength()
        {
            var input = "()())())()()()";

            int length = GetLongestValidParenthesesLength(input);

            Assert.IsTrue(length == 6);
        }
        private int GetLongestValidParenthesesLength(string input)
        {
            var stack = new Stack<int>();

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    if (stack.Count != 0 && input[stack.Peek()] == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(i);
                    }
                }
            }

            var validLength = 0;
            var right = input.Length;
            while (stack.Count > 0)
            {
                var left = stack.Peek();
                if (right - left - 1 > validLength)
                {
                    validLength = right - left - 1;
                }

                right = stack.Pop();
            } 

            if (right > validLength)
            {
                validLength = right;
            }

            return validLength;
        }
    }
}