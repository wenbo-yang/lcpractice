using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC162_FindPeakElement
{
    [TestClass]
    public class FindPeakElementTest
    {
        [TestMethod]
        public void GivenArrayWithPeakElement_FindPeakElement_ShouldReturnCorrectIndex()
        {
            var input = new int[] { 1, 2, 1, 3, 5, 6, 4 };

            var result = FindPeakElement(input);

            Assert.IsTrue(result == 1 || result == 5 );
        }

        [TestMethod]
        public void GivenAnotherArrayWithPeakElement_FindPeakElement_ShouldReturnCorrectIndex()
        {
            var input = new int[] { 1, 2, 1, 0 };

            var result = FindPeakElement(input);

            Assert.IsTrue(result == 2 );
        }

        private int FindPeakElement(int[] input)
        {
            var start = 0; var end = input.Length - 1;

            while (start < end)
            {
                var pivot = (start + end) / 2;

                if (input[pivot] < input[pivot + 1])
                {
                    start = pivot + 1;
                }
                else
                {
                    end = pivot;
                }
            }

            return end;
        }
    }
}
