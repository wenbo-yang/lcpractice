using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC35_SearchInsertPosition
{
    [TestClass]
    public class SearchInsertPositionTests
    {

        // binary search in a sorted array
        [TestMethod]
        public void GivenArrayContainingTargetValue_FindInsertPoistion_ShouldReturnPosition()
        {
            var input = new int[] { 1, 3, 5, 6 };
            var target = 5;
            var result = FindInsertPosition(input, target);

            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenArrayNotContainingTargetValue_FindInsertPoistion_ShouldReturnPosition()
        {
            var input = new int[] { 1, 3, 5, 6 };
            var target = 4;
            var result = FindInsertPosition(input, target);

            Assert.IsTrue(result == 2);
        }

        private int FindInsertPosition(int[] input, int target)
        {
            if (target <= input[0])
            {
                return 0;
            }

            if (target > input[input.Length - 1])
            {
                return input.Length;
            }

            return FindInsertPositionHelper(input, target, 0, input.Length - 1);
        }

        private int FindInsertPositionHelper(int[] input, int target, int start, int end)
        {
            if (start >= end)
            {
                return start;
            }

            var pivot = (start + end) / 2;

            if (target <= input[pivot])
            {
                return FindInsertPositionHelper(input, target, start, pivot);
            }

            return FindInsertPositionHelper(input, target, pivot + 1, end);
        }
    }
}
