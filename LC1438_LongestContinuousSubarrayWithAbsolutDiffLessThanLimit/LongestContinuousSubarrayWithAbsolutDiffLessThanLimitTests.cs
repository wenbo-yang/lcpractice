using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1438_LongestContinuousSubarrayWithAbsolutDiffLessThanLimit
{
    [TestClass]
    public class LongestContinuousSubarrayWithAbsolutDiffLessThanLimitTests
    {
        [TestMethod]
        public void GivenArray_GetLongestSubarrayWithAbsoluteDiffLessThanLimit_ShouldReturnCorrectLength()
        {
            var nums = new int[] { 8, 2, 4, 7 }; var k = 4;
            var result = GetLongestSubarraySizeWithAbsolutDiffLessOrEqualToK(nums, k);

            Assert.IsTrue(result == 2);
        }

        private int GetLongestSubarraySizeWithAbsolutDiffLessOrEqualToK(int[] nums, int k)
        {
            var max = 1;
            var increasingQueue = new LinkedList<int>();
            var decreasingQueue = new LinkedList<int>();

            var right = 0;
            var left = 0;
            while (right < nums.Length)
            {
                while (increasingQueue.Count != 0 && nums[right] < increasingQueue.Last.Value)
                {
                    increasingQueue.RemoveLast();
                }

                while (decreasingQueue.Count != 0 && nums[right] > decreasingQueue.Last.Value)
                {
                    decreasingQueue.RemoveLast();
                }

                increasingQueue.AddLast(nums[right]);
                decreasingQueue.AddLast(nums[right]);

                while (decreasingQueue.First.Value - increasingQueue.First.Value > k)
                {
                    if (decreasingQueue.First.Value == nums[left]) decreasingQueue.RemoveFirst();
                    if (increasingQueue.First.Value == nums[left]) increasingQueue.RemoveFirst();
                    left++;
                }

                max = Math.Max(max, right - left + 1);
                right++;
            }

            return max;
        }
    }
}
