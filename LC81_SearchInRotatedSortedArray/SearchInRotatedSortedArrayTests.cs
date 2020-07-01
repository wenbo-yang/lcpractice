using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC81_SearchInRotatedSortedArray
{
    [TestClass]
    public class SearchInRotatedSortedArrayTests
    {
        [TestMethod]
        public void GivenRotatedSortedArray_Search_ShouldReturnCorrectAnswer()
        {
            var nums = new int[] { 2, 5, 6, 0, 0, 1, 2};
            var target = 0;
            var result = Search(nums, target);

            Assert.IsTrue(result);
        }

        private bool Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var pivot = (right + left) / 2;
                if (nums[pivot] == target)
                {
                    return true;
                }

                if (nums[pivot] < nums[right])
                {
                    if (nums[pivot] < target && nums[right] >= target)
                    {
                        left = pivot + 1;
                    }
                    else
                    {
                        right = pivot - 1;
                    }
                }
                else if (nums[pivot] > nums[right])
                {
                    if (nums[left] <= target && nums[pivot] > target)
                    {
                        right = pivot - 1;
                    }
                    else
                    {
                        left = pivot + 1;
                    } 
                }
                else
                {
                    right--;        
                }
            }

            return false;
        }
    }
}
