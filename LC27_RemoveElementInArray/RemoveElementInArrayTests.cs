using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC27_RemoveElementInArray
{
    [TestClass]
    public class RemoveElementInArrayTests
    {
        [TestMethod]
        public void GivenArrayAndTargetValue_RemoveElementsInArray_ShouldReturnCorrectLength()
        {
            var nums = new int[] { 3, 2, 2, 3 };
            var val = 3;
            var result = RemoveElementInArray(nums, val);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenAnotherArrayAndTargetValue_RemoveElementsInArray_ShouldReturnCorrectLength()
        {
            var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var val = 2;
            var result = RemoveElementInArray(nums, val);

            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void GivenDupArrayAndTargetValue_RemoveElementsInArray_ShouldReturnCorrectLength()
        {
            var nums = new int[] { 1, 1 };
            var val = 1;
            var result = RemoveElementInArray(nums, val);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenNoTargetArrayAndTargetValue_RemoveElementsInArray_ShouldReturnCorrectLength()
        {
            var nums = new int[] { 1, 1 };
            var val = 2;
            var result = RemoveElementInArray(nums, val);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenThirdArrayAndTargetValue_RemoveElementsInArray_ShouldReturnCorrectLength()
        {
            var nums = new int[] { 2, 2, 3 };
            var val = 2;
            var result = RemoveElementInArray(nums, val);

            Assert.IsTrue(result == 1);
        }

        private int RemoveElementInArray(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            
            var lastEmptySlot = nums.Length - 1;
            var firstTargetSlot = 0;

            while (firstTargetSlot <= lastEmptySlot)
            {
                if (nums[lastEmptySlot] == val)
                {
                    lastEmptySlot--;
                    continue;
                }

                if (nums[firstTargetSlot] == val)
                {
                    var temp = nums[lastEmptySlot];
                    nums[lastEmptySlot] = nums[firstTargetSlot];
                    nums[firstTargetSlot] = temp;

                    lastEmptySlot--;
                }

                firstTargetSlot++;
            }
            
            return lastEmptySlot >= 0 ? lastEmptySlot + 1 : 0;
        }
    }
}
