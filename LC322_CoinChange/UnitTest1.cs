using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC322_CoinChange
{
    [TestClass]
    // knap sack or dfs not greedy
    public class CoinChangeTests
    {
        [TestMethod]
        public void GivenInputListOfCoins_MinCoinChange_ShouldReturnCorrectAnswer()
        {
            var input = new int[] { 1, 2, 5 };
            var target = 11;

            var result = MinCoinChange(input, target);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenInputListOfCoinsAndInvalidTarget_MinCoinChange_ShouldReturnNegative1()
        {
            var input = new int[] { 2 };
            var target = 3;

            var result = MinCoinChange(input, target);

            Assert.IsTrue(result == -1);
        }

        private int MinCoinChange(int[] input, int target)
        {
            Array.Sort(input);

            var row = input.Length;
            var col = target + 1;
            var dp = GenerateDP(row, col);
            var currentNonZeroMin = new int[col];
            InitializeDP(input, dp, currentNonZeroMin);

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    if (j == input[i])
                    {
                        dp[i][j] = 1;
                    }

                    if (j > input[i])
                    {
                        var diff = j - input[i];
                        var temp1 = currentNonZeroMin[diff] == 0 ? 0 : currentNonZeroMin[diff] + 1;
                        var temp2 = dp[i][diff] == 0 ? 0 : dp[i][diff] + 1;

                        dp[i][j] = temp2 == 0 ? temp1 : temp2;

                        
                    }

                    if (dp[i][j] != 0)
                    {
                        currentNonZeroMin[j] = dp[i][j];
                    }
                }
            }

            return currentNonZeroMin[col - 1] == 0 ? -1 : currentNonZeroMin[col - 1];
        }

        private void InitializeDP(int[] input, int[][] dp, int[] currentNonZeroMin)
        {
            for (int i = 0; i < dp[0].Length; i++)
            {
                if (i % input[0] == 0)
                {
                    dp[0][i] = i / input[0];
                    currentNonZeroMin[i] = dp[0][i];
                }
            }
        }

        private int[][] GenerateDP(int row, int col)
        {
            var dp = new int[row][];

            for(int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[col];
            }

            return dp;
        }
    }
}
