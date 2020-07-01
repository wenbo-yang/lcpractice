using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC55_JumpGame
{
    [TestClass]
    public class JumpGameTests
    {
        [TestMethod]
        public void GivenArray_CanJump_ShouldReturnCorrectAnswer()
        {
            var nums = new int[] { 2, 3, 1, 1, 4};

            var result = CanJump(nums);

            Assert.IsTrue(result);
        }

        private bool CanJump(int[] nums)
        {
            var sortedList = new SortedDictionary<int, HashSet<int>>();

            var index = 0;
            var prevIndex = 0;
            var offSet = 0;
            while (nums[index] + index < nums.Length)
            {
                prevIndex = index;
                index = CanJumpHelper(nums, index, offSet, sortedList);

                if (index == prevIndex)
                {
                    return false;
                }
                offSet = nums[prevIndex] + prevIndex;
            }

            return true;
        }

        private int CanJumpHelper(int[] nums, int index, int offSet, SortedDictionary<int, HashSet<int>> sortedList)
        {
            var num = nums[index];
            var target = nums[index] + index;
            for (int i = offSet + 1; i <= target; i++)
            {
                if (!sortedList.ContainsKey(nums[i]))
                {
                    sortedList.Add(nums[i], new HashSet<int> { i });
                }
                else
                {
                    sortedList[nums[i]].Add(i);
                }
            }

            var max = sortedList.Last().Key;
            var maxIndex = sortedList.Last().Value.First();
            var current = index + 1;


            while (current <= maxIndex)
            {
                if (sortedList[nums[current]].Contains(current))
                {
                    sortedList[nums[current]].Remove(current);
                }

                if (sortedList[nums[current]].Count == 0)
                {
                    sortedList.Remove(nums[current]);
                }

                current++;
            }

            return current - 1;
        }
    }
}
