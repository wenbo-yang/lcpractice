using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1235_MaximumProfitInJobScheduling
{
    [TestClass]
    public class MaximumProfitInJobSchedulingTests
    {
        [TestMethod]
        public void GivenStartEndAndProfit_GetMaxProfit_ShouldReturnCorrectAnswer()
        {
            var startTime = new int[] { 1, 2, 3, 4, 6 };
            var endTime = new int[] { 3, 5, 10, 6, 9 };
            var profit = new int[] { 20, 20, 100, 70, 60 };

            var result = GetMaxProfit(startTime, endTime, profit);

            Assert.IsTrue(result == 150);
        }

        private int GetMaxProfit(int[] startTime, int[] endTime, int[] profit)
        {

            var maxProfit = new Dictionary<int, int>();
            var startIndex = 0;
            while(startIndex < startTime.Length)
            {
                GetMaxProfitHelper(startIndex, startTime, endTime, profit, maxProfit);
                startIndex++;
            }

            var array = new int[maxProfit.Count];
            maxProfit.Values.CopyTo(array, 0);

            return array.Max();
        }

        private int GetMaxProfitHelper(int startIndex, int[] startTime, int[] endTime, int[] profit, Dictionary<int, int> maxProfit)
        {
            if (startIndex >= startTime.Length)
            {
                return 0;
            }

            if (maxProfit.ContainsKey(startIndex))
            {
                return maxProfit[startIndex];
            }

            var right = startIndex;
            while (right < startTime.Length && startTime[right] == startTime[startIndex])
            {
                right++;
            }

            var max = int.MinValue;
            for (int i = startIndex; i < right; i++)
            {
                var tempProfit = profit[startIndex];

                for (int j = 0; j < startTime.Length; j++)
                {
                    var subsequentMax = int.MinValue;
                    if (startTime[j] >= endTime[i])
                    {
                        subsequentMax = Math.Max(subsequentMax, GetMaxProfitHelper(j, startTime, endTime, profit, maxProfit));
                        max = Math.Max(max, tempProfit + subsequentMax);
                    }
                }
            }

            maxProfit.Add(startIndex, max);

            return maxProfit[startIndex];
        }
    }
}
