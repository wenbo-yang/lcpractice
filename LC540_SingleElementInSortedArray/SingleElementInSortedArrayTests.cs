using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC540_SingleElementInSortedArray
{
    [TestClass]
    public class SingleElementInSortedArrayTests
    {
        [TestMethod]
        public void GivenSortedArrayWithOneSingleElement_FindSingleElement_ShouldReturnSingleElement()
        {
            var input = new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            var result = FindSingleElement(input);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void GivenAnotherSortedArrayWithOneSingleElement_FindSingleElement_ShouldReturnSingleElement()
        {
            var input = new int[] { 1, 1, 2, 2, 4, 4, 5, 5, 6, 8, 8 };
            var result = FindSingleElement(input);
            Assert.IsTrue(result == 6);
        }
        [TestMethod]
        public void GivenSingleEndingNumberInSortedArrayWithOneSingleElement_FindSingleElement_ShouldReturnSingleElement()
        {
            var input = new int[] { 1, 1, 2, 2, 4, 4, 5, 5, 8, 8, 9 };
            var result = FindSingleElement(input);
            Assert.IsTrue(result == 9);
        }

        private int FindSingleElement(int[] input)
        {
            var start = 0; var end = input.Length - 1;
            var pivot = (start + end) / 2;
            while (!IsPivotSingleChar(pivot, start, end, input))
            {
                if (IsInFirstHalf(pivot, input))
                {
                    end = pivot;
                }
                else
                {
                    start = pivot + 1;
                }

                pivot = (start + end) / 2;
            }

            return input[pivot];
        }

        private bool IsInFirstHalf(int pivot, int[] input)
        {
            return pivot > 0 && (input[pivot] == input[pivot - 1]) && pivot % 2 == 0;
        }

        private bool IsPivotSingleChar(int pivotIndex, int start, int end, int[] input)
        {
            if(start >= end || pivotIndex == input.Length - 1|| pivotIndex == 0)
            {
                return true;
            }

            return !(input[pivotIndex] == input[pivotIndex - 1] || input[pivotIndex] == input[pivotIndex + 1]);
        }
    }
}
