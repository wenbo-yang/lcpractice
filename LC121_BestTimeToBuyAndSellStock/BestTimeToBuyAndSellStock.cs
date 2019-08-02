using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC121_BestTimeToBuyAndSellStock
{
    [TestClass]
    public class BestTimeToBuyAndSellStock
    {
        // transfrom this into max sum subarray
        // 122, 123 are also here
        [TestMethod]
        public void GivenStockPrice_MaxProfit_ShouldGrenerateMaxProfit()
        {
            var input = new int[] { 7, 1, 5, 3, 6, 4 };

            int maxProfit = MaxProfit(input);

            Assert.IsTrue(maxProfit == 5);
        }

        [TestMethod]
        public void GivenStockLossingMoney_MaxProfit_ShouldOutputZero()
        {
            var input = new int[] { 7, 6, 5, 4, 3, 2 };

            int maxProfit = MaxProfit(input);

            Assert.IsTrue(maxProfit == 0);
        }

        [TestMethod]
        public void GivenStockPrice_MaxProfitMultipleTrades_ShouldGrenerateMaxProfit()
        {
            var input = new int[] { 7, 1, 5, 3, 6, 4 };

            int maxProfit = MaxProfitMultipleTrades(input);

            Assert.IsTrue(maxProfit == 7);
        }

        private int MaxProfitMultipleTrades(int[] input)
        {

            var diff = TransfromToDiffArray(input);

            var currentSum = 0;
            var index = 0;
            while (index < diff.Length)
            {
                if (diff[index] >= 0)
                {
                    currentSum += diff[index];
                }

                index++;
            }

            return currentSum;
        }

        

        private int MaxProfit(int[] input)
        {
            // turn into diff array
            var diff = TransfromToDiffArray(input);

            var maxProfit = GetMaximumSubArraySum(diff);

            return maxProfit < 0 ? 0 : maxProfit;
        }

        private int[] TransfromToDiffArray(int[] input)
        {
            var output = new int[input.Length - 1];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = input[i + 1] - input[i];
            }

            return output;
        }

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

            for (int i = 0; i < input.Length; i++)
            {
                currentMax = input[i] > currentMax ? input[i] : currentMax;
            }

            return currentMax;
        }




    }
}
