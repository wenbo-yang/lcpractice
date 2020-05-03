using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1343_NumOfSubArraysOfSizeK
{
    [TestClass]
    public class NumberOfSubarrayOfSizeKandAverageGreaterThanOrEqualToThresholdTests
    {
        [TestMethod]
        public void GivenArrayAndK_GetNumberOfSubarrays_ShouldReturnNumberOfSubarrays()
        {
            var array = new int[] { 2, 2, 2, 2, 5, 5, 5, 8};
            var k = 3;
            var threshold = 4;

            var num = GetNumberOfSubarrays(array, k, threshold);

            Assert.IsTrue(num == 3);
        }

        private int GetNumberOfSubarrays(int[] array, int k, int threshold)
        {
            var left = 0;
            var right = k - 1;
            var adjustedThreshold = threshold * k;
            var currentSumOfWindowK = 0;
            var count = 0;
            for (int i = 0; i < k; i++)
            {
                currentSumOfWindowK += array[i];
            }

            while (right < array.Length)
            {
                if (left != 0)
                {
                    currentSumOfWindowK -= array[left];
                    currentSumOfWindowK += array[right];
                }

                if (currentSumOfWindowK >= adjustedThreshold)
                {
                    count++;
                }

                right++;
                left++;
            }

            return count;
        }
    }
}
