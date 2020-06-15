using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC16_3SumClosest
{
    [TestClass]
    public class ThreeSumClosestTests
    {
        [TestMethod]
        public void GivenArray_ThreeSumClosest_ShouldReturnCorrectAnswer()
        {
            var nums = new int[] { -1, 2, 1, -4 };
            var result = ThreeSumClosest(nums, 1);
            Assert.IsTrue(result == 2);
        }

        private int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);

            var diff = int.MaxValue;
            var closest = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var twoSum = TwoSumWithMask(nums, i, target - nums[i]);
                if (Math.Abs(twoSum + nums[i] - target) < diff)
                {
                    diff = Math.Abs(twoSum + nums[i] - target);
                    closest = twoSum + nums[i];
                    if (diff == 0)
                    {
                        return target;
                    }
                }
            }

            return closest;
        }

        private int TwoSumWithMask(int[] nums, int mask, int target)
        {
            var closest = int.MaxValue;
            var sum = 0;

            var left = 0; var right = nums.Length - 1;

            while (left < right)
            {
                if (left == mask)
                {
                    left++;
                    continue;
                }
                if (right == mask)
                {
                    right--;
                    continue;
                }


                var currentDiff = Math.Abs(nums[left] + nums[right] - target);
                if (currentDiff > closest)
                {
                    break;
                }
                else
                {
                    closest = currentDiff;
                }

                sum = nums[left] + nums[right];

                if (sum == target)
                {
                    return sum;
                }

                if (sum < target)
                {
                    left++;
                    continue;
                }

                if (sum > target)
                {
                    right--;
                    continue;
                }
            }

            return sum;
        }
    }
}
