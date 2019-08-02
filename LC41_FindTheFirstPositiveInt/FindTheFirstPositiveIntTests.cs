using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC41_FindTheFirstPositiveInt
{
    [TestClass]
    public class FindTheFirstPositiveIntTests
    {
        [TestMethod]
        // use hash / bucket sort
        public void GivenSortedArray_FindFirstMissingPositive_ShouldReturnCorrectNextInteger()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            var result = FindFirstMissingPositive(input);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        // use hash / bucket sort
        public void GivenUnsortedArray_FindFirstMissingPositive_ShouldReturnCorrectNextInteger()
        {
            var input = new int[] { 3, 4, 0, -1, 1};
            var result = FindFirstMissingPositive(input);

            Assert.IsTrue(result == 2);
        }

        private int FindFirstMissingPositive(int[] input)
        {
            var index = 0;
            var bucket = input;

            while (index < bucket.Length)
            {
                var targetIndex = bucket[index] - 1;

                if (targetIndex == index)
                {
                    index++;
                    continue;
                }

                if (targetIndex < 0 || targetIndex > bucket.Length - 1 || bucket[index] == bucket[targetIndex])
                {
                    bucket[index++] = 0;
                }
                else
                {
                    // swap
                    var temp = bucket[targetIndex];
                    bucket[targetIndex] = bucket[index];
                    bucket[index] = temp;
                }
            }

            var result = bucket.Length + 1;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] == 0)
                {
                    result = i + 1;
                    break;
                }
            }

            return result;
        }
    }
}
