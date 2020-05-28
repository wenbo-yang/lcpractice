using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1425_ConstrainedSubsequenceSum
{
    [TestClass]
    public class ConstrainedSubsequenceSumTests
    {
        [TestMethod]
        public void GivenSequence_ConstrainedSubsequenceSum_ShouldReturnCorrectSum()
        {
            var nums = new int[] { 10, 2, -10, 5, 20 }; var k = 2;
            var result = ConstrainedSubsequenceSum(nums, k);

            Assert.IsTrue(result == 37);
        }

        [TestMethod]
        public void GivenNegativeSequence_ConstrainedSubsequenceSum_ShouldReturnCorrectSum()
        {
            var nums = new int[] { -1, -2, -3}; var k = 1;
            var result = ConstrainedSubsequenceSum(nums, k);

            Assert.IsTrue(result == -1);
        }

        private int ConstrainedSubsequenceSum(int[] nums, int k)
        {
            var windowSize = k - 1;

            var index = 0;
            var sum = 0;
            var maxSum = int.MinValue;
            while (index < nums.Length)
            {
                if (nums[index] < 0)
                {
                    var result = FindSlidingWindowMinimum(nums, index, windowSize);
                    index = result.lastIndex;
                    sum += result.remaining;
                }
                else
                {
                    sum += nums[index];
                }

                if (sum < 0)
                {
                    maxSum = Math.Max(maxSum, nums[index]);
                }
                else
                {
                    maxSum = Math.Max(maxSum, sum);
                }

                index++;
            }

            return maxSum;
        }

        private (int remaining, int lastIndex) FindSlidingWindowMinimum(int[] nums, int startIndex, int windowSize)
        {
            if (windowSize == 0)
            {
                return (nums[startIndex], startIndex);
            }

            var endIndex = startIndex;
            while (endIndex < nums.Length && nums[endIndex] < 0)
            {
                endIndex++;
            }

            endIndex--;
            var totalSize = (endIndex - startIndex + 1);

            var remaining = int.MinValue;

            if (windowSize >= totalSize)
            {
                return (0, endIndex);
            }
            else
            {
                var max = totalSize / windowSize + 1;
                var min = 0;
                var index = 0;
                while (index < max)
                {
                    min = 0;
                    var offSet = windowSize;
                    var tempIndex = index;
                    while (tempIndex <= endIndex)
                    {
                        min += nums[tempIndex];
                        tempIndex += offSet;
                    }

                    remaining = Math.Max(remaining, min);
                }
            }

            return (remaining, endIndex);
        }
    }
}
