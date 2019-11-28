using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC560_SubarraySumEqualsK
{
    [TestClass]
    public class SubarraySumEqualsKTests
    {
        [TestMethod]
        public void GivenArray_GetNumSubarrayEqualsK_ShouldReturnCorrectAnswer()
        {
            var input = new int[] { 1, 1, 1, 5, 1, 1 };
            var targetSum = 2;
            var result = GetNumSubarrayEqualsK(input, targetSum);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenNumArray_GetNumSubarrayEqualsK_ShouldReturn0()
        {
            var input = new int[] { 1, 1, 1, 5, 1, 1 };
            var targetSum = 0;
            var result = GetNumSubarrayEqualsK(input, targetSum);

            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void GivenArrayTargetZero_GetNumSubarrayEqualsK_ShouldReturnCorrectAnswer()
        {
            var input = new int[] { 1, -1, 1, 5, 1, 1 };
            var targetSum = 0;
            var result = GetNumSubarrayEqualsK(input, targetSum);

            Assert.IsTrue(result == 2);
        }

        private int GetNumSubarrayEqualsK(int[] input, int targetSum)
        {
            var sum = new int[input.Length];
            sum[0] = input[0];

            for (int i = 1; i < input.Length; i++)
            { 
                sum[i] = sum[i - 1] + input[i];
            }

            var sumFrequencyTable = new Dictionary<int, int> { {0, 1} };

            var result = 0;
            for (int i = 0; i < sum.Length; i++)
            {
                if (sumFrequencyTable.ContainsKey(sum[i] - targetSum))
                {
                    result += sumFrequencyTable[sum[i] - targetSum];
                }

                if (!sumFrequencyTable.ContainsKey(sum[i]))
                {
                    sumFrequencyTable.Add(sum[i], 0);
                }

                sumFrequencyTable[sum[i]]++;
            }

            return result;
        }
    }
}
