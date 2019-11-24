using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC739_NumberOfDaysToWaitForHigherTemp
{
    [TestClass]
    public class NumberOfDaysToWaitForHigherTempTests
    {
        [TestMethod]
        public void GivenDailyTemp_FindNumOfDaysForHigherTemp_ShouldReturnCorrectArray()
        {
            var input = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };

            var result = FindNumOfDaysToHigherTemp(input);

            Assert.IsTrue(result.SequenceEqual(new int[] { 1, 1, 4, 2, 1, 1, 0, 0 }));
        }

        private int[] FindNumOfDaysToHigherTemp(int[] input)
        {
            var result = new int[input.Length];
            var stack = new Stack<Tuple<int, int>>();

            for (int i = 1; i < input.Length; i++)
            {
                if (stack.Count != 0)
                {
                    var top = stack.Peek();
                    if (top.Item1 < input[i])
                    {
                        result[top.Item2] = i - top.Item2;
                        stack.Pop();
                    }
                }

                if (input[i] > input[i - 1]) // ascending array
                {
                    result[i - 1] = 1;
                }
                else
                {
                    stack.Push(new Tuple<int, int>(input[i - 1], i - 1));
                }
            }

            while (stack.Count != 0)
            {
                result[stack.Pop().Item2] = 0;
            }

            return result;
        }
    }
}
