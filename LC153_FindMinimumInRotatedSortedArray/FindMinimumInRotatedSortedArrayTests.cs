using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC153_FindMinimumInRotatedSortedArray
{
    [TestClass]
    // 154 is here as well
    // only 154 is implemented
    public class FindMinimumInRotatedSortedArrayTests
    {
        [TestMethod]
        public void GivenRotatedArray_FindMinimum_ShouldReturnMinimum()
        {
            var array = new int[] { 2, 2, 2, 0, 1, 2 };

            var result = FindMinimum(array);

            Assert.IsTrue(result == 0);
        }

        private int FindMinimum(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Invalid params");
            }

            return FindMinimumHelper(array, 0, array.Length - 1);
        }

        private int FindMinimumHelper(int[] array, int start, int end)
        {
            if (start == end || array[start] < array[end])
            {
                return array[start];
            }

            var pivot = (start + end) / 2;

            var right = FindMinimumHelper(array, pivot + 1, end);

            if (array[start] == array[end] && array[start] == array[pivot])
            {
                return Math.Min(array[start], right);
            }

            return Math.Min(FindMinimumHelper(array, start, pivot), right);
        }
    }
}
