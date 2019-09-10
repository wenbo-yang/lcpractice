using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC300_LongestIncreasingSubsequence
{
    [TestClass]
    public class LongestIncreasingSubsequenceTests
    {
        [TestMethod]
        public void GivenArray_GetLongestIncreasingSubsequenceLength_ShouldReturnLength()
        {
            var input = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            var result = GetIncreasingSubsequenceLength(input);

            Assert.IsTrue(result == 4);
        }

        private int GetIncreasingSubsequenceLength(int[] input)
        {
            var dp = new int[input.Length];
            
            for (int i = 0; i < input.Length; i++)
            {
                var lastSmallerIndex = FindLastSmallerItemIndex(input, i);

                if (lastSmallerIndex == -1)
                {
                    dp[i] = 1;
                }
                else
                {
                    dp[i] = dp[lastSmallerIndex] + 1;
                }
            }

            return dp[dp.Length - 1];
        }

        private int FindLastSmallerItemIndex(int[] input, int targetIndex)
        {
            for (int i = targetIndex - 1; i >= 0; i--)
            {
                if (input[i] < input[targetIndex])
                {
                    return i;
                }
            }

            return -1;
        }

    }
}
