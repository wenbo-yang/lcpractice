using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1403_MinimumSubsequence
{
    [TestClass]
    public class MinimumSubsequenceTests
    {
        [TestMethod]
        public void GivenArray_GetMinimumSequence_ShouldReturnCorrectSequence()
        {
            var array = new int[] { 4, 3, 10, 9, 8 };
            var result = GetMinimumSequence(array);

            Assert.IsTrue(result.SequenceEqual(new List<int> { 10, 9 }));

        }

        private List<int> GetMinimumSequence(int[] array)
        {
            var result = new List<int>();

            Array.Sort(array);
            var remainingSum = array.Sum();
            var sequenceSum = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sequenceSum += array[i];
                remainingSum -= array[i];

                result.Add(array[i]);

                if (sequenceSum > remainingSum)
                {
                    break;
                }
            }

            return result;
        }
    }
}
