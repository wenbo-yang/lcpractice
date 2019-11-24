using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC724_FindPivotIndex
{
    [TestClass]
    public class FindPivotIndexTests
    {
        [TestMethod]
        public void GivenArray_FindPivotIndex_ShouldReturnPivotIndex()
        {
            var input = new int[] { 1, 7, 3, 6, 5, 6 };
            var result = FindPivotIndex(input);

            Assert.IsTrue(result == 3);
        }

        private int FindPivotIndex(int[] input)
        {
            var forwardSum = new int[input.Length];
            var backwardSum = new int[input.Length];

            forwardSum[0] = input[0];
            backwardSum[input.Length - 1] = input[input.Length - 1];

            for (int i = 1; i < input.Length; i++)
            {
                forwardSum[i] = forwardSum[i - 1] + input[i];
                backwardSum[input.Length - 1 - i] = backwardSum[input.Length - i] + input[input.Length - 1 - i];
            }

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (forwardSum[i - 1] == backwardSum[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
