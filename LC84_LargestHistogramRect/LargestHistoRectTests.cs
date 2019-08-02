using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC84_LargestHistogramRect
{
    [TestClass]
    // same as containing most water
    public class LargestHistoRectTests
    {
        [TestMethod]
        public void GivenArray_FindLargestRect_ShouldReturnCorrectResult()
        {
            var input = new int[] {2, 1, 5, 6, 2, 3 };

            int result = FindLargestRect(input);

            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void GivenAscendingArray_FindLargestRect_ShouldReturnCorrectResult()
        {
            var input = new int[] {1, 2, 3};

            int result = FindLargestRect(input);

            Assert.IsTrue(result == 4);
        }
        [TestMethod]
        public void GivenDescendingArray_FindLargestRect_ShouldReturnCorrectResult()
        {
            var input = new int[] { 3, 2, 1 };

            int result = FindLargestRect(input);

            Assert.IsTrue(result == 4);
        }

        private int FindLargestRect(int[] input)
        {
            var max = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 < input.Length && input[i] <= input[i + 1])
                {
                    continue;
                }

                int minH = input[i];

                for (int j = i; j >= 0; j--)
                {
                    minH = Math.Min(minH, input[j]);

                    var curr = minH * (i - j + 1);

                    max = Math.Max(max, curr);
                }
            }

            return max;
        }
    }
}
