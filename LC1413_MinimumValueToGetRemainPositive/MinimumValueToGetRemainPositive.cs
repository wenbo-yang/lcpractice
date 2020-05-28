using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1413_MinimumValueToGetRemainPositive
{
    [TestClass]
    public class MinimumValueToGetRemainPositive
    {
        [TestMethod]
        public void GivenArray_GetMinStartingValue_ShouldReturnMinStartingValue()
        {
            var nums = new int[] { -3, 2, -3, 4, 2 };
            var result = GetMinStartingValue(nums);

            Assert.IsTrue(result == 5);
        }

        private int GetMinStartingValue(int[] nums)
        {
            var minSum = 0;
            var currentSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                currentSum += nums[i];
                minSum = Math.Min(currentSum, minSum);
            }

            return minSum < 0 ? 1 - minSum : 1;
        }
    }
}
