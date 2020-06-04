using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1304_FindNUniqueIntegersSumToZero
{
    [TestClass]
    public class FindNUniqueIntegersSumToZeroTests
    {
        [TestMethod]
        public void GivenInteger_SumZeroArray_ShouldReturnCorrectAnswer()
        {
            var n = 5;
            var result = SumZeroArray(n);

            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 1, 2, 3, -6 }));
        }

        private int[] SumZeroArray(int n)
        {
            var arr = new int[n];
            var sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                sum += i;
                arr[i] = i;
            }

            arr[arr.Length - 1] = -1 * sum;

            return arr;
        }
    }
}
