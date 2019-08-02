using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC42_TrappingRainWater
{
    [TestClass]
    public class TrappingRainWaterTests
    {

        // use stack
        [TestMethod]
        public void GivenArray_TrapRainWater_ShouldGenerateCorrectOutput()
        {
            var input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            int output = Bucket(input);

            Assert.IsTrue(output == 6);
        }

        private int Bucket(int[] input)
        {
            // assume input is not null or empty
            var result = 0;
            var stack = new Stack<int>();

            stack.Push(0);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= input[stack.Peek()])
                {
                    stack.Pop();
                }

                stack.Push(i);
            }

            if (stack.Count < 2)
            {
                return 0;
            }
              
            var right = stack.Pop();
            var left = stack.Pop();

            while(stack.Count != 0)
            {
                if (input[left] > input[right] || input[left] >= input[stack.Peek()])
                {
                    result += Calculate(input, left, right);
                    right = left;
                }

                left = stack.Pop();
            }

            result += Calculate(input, left, right);

            return result;
        }

        private int Calculate(int[] input, int left, int right)
        {
            var width = right - left - 1;

            var result = width * Math.Min(input[left], input[right]);

            for (int i = left + 1; i < right; i++)
            {
                result -= input[i];
            }

            return result;
        }
    }
}
