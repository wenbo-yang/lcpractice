using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC674_LongestIncreasingSubsequence
{
    [TestClass]
    public class LongestIncreasingSubarrayTests
    {
        [TestMethod]
        public void GivenArray_GetLongestIncreasingSubarrayLength_ShouldReturnCorrectAnswer()
        {
            var array = new int[] { 1, 3, 5, 4, 7 };

            var result = GetLongestIncreasingSubarrayLength(array);

            Assert.IsTrue(result == 3);
        }

        private int GetLongestIncreasingSubarrayLength(int[] array)
        {
            var currentMax = 1;

            var left = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] <= array[i - 1])
                {
                    currentMax = Math.Max(currentMax, i - left);
                    left = i;
                }
            }

            return currentMax;
        }
    }
}
