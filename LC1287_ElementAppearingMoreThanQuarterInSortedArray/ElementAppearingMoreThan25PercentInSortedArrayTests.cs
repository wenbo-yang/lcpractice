using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1287_ElementAppearingMoreThanQuarterInSortedArray
{
    [TestClass]
    public class ElementAppearingMoreThan25PercentInSortedArrayTests
    {
        [TestMethod]
        public void GivenSortedArray_FindQuarterInteger_ShouldReturnCorrectInteger()
        {
            var input = new int[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 };
            var result = FindQuarterInteger(input);

            Assert.IsTrue(result == 6);
        }

        private int FindQuarterInteger(int[] input)
        {
            var left = 0;
            var threshold = input.Length % 4 == 0 ? input.Length / 4 : input.Length / 4 + 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[left] || i == input.Length - 1)
                {
                    var count = i - left;

                    if (count >= threshold)
                    {
                        return input[left];
                    }

                    left = i;
                }
            }

            throw new ArgumentException();
        }
    }
}
