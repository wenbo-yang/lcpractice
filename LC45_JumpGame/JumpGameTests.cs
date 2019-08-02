using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC45_JumpGame
{
    [TestClass]
    // greedy 
    public class JumpGameTests
    {
        [TestMethod]
        public void GivenArray_Jump_ShouldYieldCorrectResult()
        {
            var input = new int[] { 2, 3, 1, 1, 4 };

            int result = Jump(input);

            Assert.IsTrue(result == 2);
        }

        private int Jump(int[] input)
        {
            var numJumps = 0;
            var currentIndex = 0;
            var endIndex = 0;

            while (endIndex < input.Length - 1)
            {
                var startIndex = endIndex;
                endIndex = currentIndex + input[currentIndex];

                currentIndex = FindMaxIndex(input, startIndex, endIndex);
                numJumps++;
            }

            return numJumps;
        }

        private int FindMaxIndex(int[] array, int startIndex, int endIndex)
        {
            var currentMaxIndex = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (array[currentMaxIndex] < array[i])
                {
                    currentMaxIndex = i;
                }
            }

            return currentMaxIndex;
        }
    }
}
