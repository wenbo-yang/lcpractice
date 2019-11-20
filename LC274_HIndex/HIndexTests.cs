using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC274_HIndex
{
    [TestClass]
    // bucket sort ?
    public class HIndexTests
    {
        [TestMethod]
        public void GivenArray_FindHIndex_ShouldReturnCorrectIndex()
        {
            var input = new int[] { 3, 0, 6, 1, 5 };

            var result = FindHIndex(input);

            Assert.IsTrue(result == 3);
        }

        private int FindHIndex(int[] input)
        {
            var bucket = new int[input.Length];
            var total = input.Length;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= input.Length)
                {
                    bucket[input.Length - 1]++;

                }
                else
                {
                    bucket[input[i]]++;
                }
            }

            var count = 0;

            for (int i = bucket.Length - 1; i >= 0; i--)
            {
                count += bucket[i];

                if (count > i)
                {
                    return i + 1;
                }
            }

            return 0;
        }
    }
}
