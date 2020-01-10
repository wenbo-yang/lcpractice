using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC132_PalindromePartitioningII
{
    [TestClass]
    public class PalidromePartitioningIITests
    {
        [TestMethod]
        public void GivenString_FindMinCut_ShouldReturnMinimumCut()
        {
            var input = "abacab";

            var result = FindMinCut(input);

            Assert.IsTrue(result == 1);
        }

        private int FindMinCut(string input)
        {
            var dp = GenerateAndInitializeDP(input);
            FindPalidromeSubstring(dp, input);

            var minCutTable = new Dictionary<(int start, int end), int>();

            return GetMinPartitioningCounts(dp, minCutTable, 0, input.Length - 1) - 1;
        }

        private int GetMinPartitioningCounts(bool[][] dp, Dictionary<(int start, int end), int> minCutTable, int start, int end)
        {
            if (dp[start][end] || dp[end][start])
            {
                if (!minCutTable.ContainsKey((start, end)))
                {
                    minCutTable.Add((start, end), 1);
                }

                return 1;
            }

            if (minCutTable.ContainsKey((start, end)))
            {
                return minCutTable[(start, end)];
            }

            var min = int.MaxValue;

            var partition = start;

            while (partition < end)
            {
                var sum = GetMinPartitioningCounts(dp, minCutTable, start, partition) + GetMinPartitioningCounts(dp, minCutTable, partition + 1, end);
                min = Math.Min(sum, min);

                partition++;
            }

            minCutTable.Add((start, end), min);

            return minCutTable[(start, end)];
        }

        private void FindPalidromeSubstring(bool[][] dp, string input)
        {
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[0].Length; j++)
                {
                    if (i != j )
                    {
                        dp[i][j] = input[i] == input[j];

                        if (j - i > 1)
                        {
                            dp[i][j] = dp[i][j] && dp[i + 1][j - 1];
                        }
                        else if(i - j > 1)
                        {
                            dp[i][j] = dp[i][j] && dp[i - 1][j + 1];
                        }
                    }
                }
            }
        }

        private bool[][] GenerateAndInitializeDP(string input)
        {
            var dp = new bool[input.Length][];
            for (int i = 0; i < input.Length; i++)
            {
                dp[i] = new bool[input.Length];
                dp[i][i] = true;
            }

            return dp;
        }
    }
}
