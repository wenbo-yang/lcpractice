using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC34_FindFirstAndLastOccurenceOfNumberInSortedArray
{
    [TestClass]
    public class FindFirstAndLastOccurenceOfNumberInSortedArray
    {
        [TestMethod]
        public void GivenArrayAndTarget_FindFirstAndLast_ShouldReturnCorrectResult()
        {
            var input = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 2, 2 };
            var target = 1;
            var result = FindFirstAndLastIndex(input, target);

            Assert.IsTrue(result.Item1 == 3);
            Assert.IsTrue(result.Item2 == 7);
        }

        private Tuple<int, int> FindFirstAndLastIndex(int[] input, int target)
        {
            var result = FindFirstAndLastOccurrenceHelper(input, target, 0, input.Length - 1);

            if (result.Item1 == int.MaxValue)
            {
                return new Tuple<int, int>(-1, -1);
            }

            return result;
        }

        private Tuple<int, int> FindFirstAndLastOccurrenceHelper(int[] input, int target, int start, int end)
        {
            if (input[start] > target || input[end] < target || start > end)
            {
                return new Tuple<int, int>(int.MaxValue, int.MinValue);
            }

            if (input[start] == target && input[end] == target)
            {
                return new Tuple<int, int>(start, end);
            }

            var pivot = (start + end) / 2;
   
            var fromLeft = FindFirstAndLastOccurrenceHelper(input, target, 0, pivot);
            var fromRight = FindFirstAndLastOccurrenceHelper(input, target, pivot + 1, end);

            return new Tuple<int, int>(Math.Min(fromLeft.Item1, fromRight.Item1), Math.Max(fromLeft.Item2, fromRight.Item2));  
       }
    }
}
