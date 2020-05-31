using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1464_MaxProduct
{
    [TestClass]
    public class MaxProductTests
    {
        [TestMethod]
        public void GivenArray_MaxProductOfTwoElements_ShouldReturnCorrectAnswer()
        {
            var nums = new int[] { 3, 4, 5, 2 };
            var result = MaxProduct(nums);

            Assert.IsTrue(result == 12);
        }

        private int MaxProduct(int[] nums)
        {
            var max = Math.Max(nums[0], nums[1]);
            var second = max == nums[0] ? nums[1] : nums[0];
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    second = max;
                    max = nums[i];
                }
                else if (nums[i] > second)
                {
                    second = nums[i];
                }
            }

            return (max - 1) * (second - 1);
        }
    }
}
