using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC152_MaxProductSubArray
{
    [TestClass]
    public class MaxProductSubArrayTests
    {
        [TestMethod]
        public void GivenArray_FindMaxProduct_ShouldReturnCorrectResult()
        {
            var input = new int[] { 2, 3, -2, 4 };
            var result = FindMaxProduct(input);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenArrayWithEvenNegatives_FindMaxProduct_ShouldReturnCorrectResult()
        {
            var input = new int[] { -2, 3, -2, 4 };
            var result = FindMaxProduct(input);

            Assert.IsTrue(result == 48);
        }

        [TestMethod]
        public void GivenArrayWithStarting0_FindMaxProduct_ShouldReturnCorrectResult()
        {
            var input = new int[] { 0, -2, 3, -2, 4 };
            var result = FindMaxProduct(input);

            Assert.IsTrue(result == 48);
        }

        [TestMethod]
        public void GivenArray_FindMaxProductDP_ShouldReturnCorrectResult()
        {
            var input = new int[] { 2, 3, -2, 4 };
            var result = FindMaxProductDP(input);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenArrayWithEvenNegatives_FindMaxProductDP_ShouldReturnCorrectResult()
        {
            var input = new int[] { -2, 3, -2, 4 };
            var result = FindMaxProductDP(input);

            Assert.IsTrue(result == 48);
        }

        [TestMethod]
        public void GivenArrayWith0_FindMaxProductDP_ShouldReturnCorrectResult()
        {
            var input = new int[] { -2, 3, 0, -2, -4 };
            var result = FindMaxProductDP(input);

            Assert.IsTrue(result == 8);
        }

        private int FindMaxProductDP(int[] input)
        {
            int current_max = 0;
            int current_min = 0;
            var result = 0;

            int dp_min = input[0];
            int dp_max = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                current_min = dp_min * input[i];
                current_max = dp_max * input[i];

                dp_max = Math.Max(Math.Max(current_min, current_max), input[i]);
                dp_min = Math.Min(Math.Min(current_min, current_max), input[i]);

                result = Math.Max(dp_max, result);
            }

            return result;
        }

        private int FindMaxProduct(int[] input)
        {
            var result = int.MinValue;
            var productUpToFirstNegative = 1;
            var productFromLastNegative = 1;
            var firstNegativeIndex = -1;
            var lastNegativeIndex = -1;
            var productSoFar = 0;
            var startIndex = 0;

            while (startIndex < input.Length)
            {
                if (input[startIndex] != 0)
                {
                    productSoFar = 1;
                    break;
                }

                startIndex++;
            }

            for (int i = startIndex; i < input.Length; i++)
            {
                if (input[i] == 0)
                {
                    result = Math.Max(result, productSoFar < 0 ? Math.Max(productSoFar / productUpToFirstNegative, productSoFar / productFromLastNegative) : productSoFar);
                    productSoFar = 1;
                    firstNegativeIndex = -1;
                    lastNegativeIndex = -1;
                    productUpToFirstNegative = 1;
                    productFromLastNegative = 1;
                    continue;
                }

                productSoFar *= input[i];

                if (input[i] < 0)
                {
                    if (firstNegativeIndex == -1)
                    {
                        productUpToFirstNegative = productSoFar;
                        firstNegativeIndex = i;
                        lastNegativeIndex = i;
                    }

                    if (lastNegativeIndex < i)
                    {
                        lastNegativeIndex = i;
                        productFromLastNegative = 1;
                    }
                }

                if (lastNegativeIndex != -1)
                {
                    productFromLastNegative *= input[i];
                }
            }

            result = Math.Max(result, productSoFar < 0 ? Math.Max(productSoFar / productUpToFirstNegative, productSoFar / productFromLastNegative) : productSoFar);

            return result;
        }

        

        
    }
}
