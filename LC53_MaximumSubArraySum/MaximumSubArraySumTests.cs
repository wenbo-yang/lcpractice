using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC53_MaximumSubArraySum
{
    [TestClass]
    public class MaximumSubArraySumTests
    {
        [TestMethod]
        public void GivenArray_GetMaximum_ShouldReturnCorrectResult()
        {
            var input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int result = GetMaximumSubArraySum(input);
            Assert.IsTrue(result == 6);
        }


        // dp ? sliding window?
        private int GetMaximumSubArraySum(int[] input)
        {
            var sum = Max(input);

            if (sum < 0 || input.Length == 1)
            {
                return sum;
            }

            var left = 0;
            var right = 0;
            var currentSum = input[0];

            while (right < input.Length)
            {
                // find the first positive
                if (left == right)
                {
                    if (input[left] <= 0)
                    {
                        left++;
                        right++;
                        continue;
                    }

                    // set currentSum to 0;
                    // reset the conditions
                    currentSum = 0;
                }

                // get the current sum, if left == right 
                // then currentSum == input[right]
                currentSum = currentSum + input[right++];

                if (currentSum <= 0)
                {
                    left = right;
                    continue;
                }

                if (currentSum > sum)
                {
                    sum = currentSum;
                }
            }

            return sum;
        }

        private int Max(int[] input)
        {
            var currentMax = int.MinValue;

            for(int i = 0; i < input.Length; i++ )
            {
                currentMax = input[i] > currentMax ? input[i] : currentMax;
            }

            return currentMax;
        }
    }
}
