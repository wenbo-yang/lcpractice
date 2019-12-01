using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1269_NumberOfWaysToStayAtTheSamePlace
{
    [TestClass]
    public class NumberOfWaysToStayAtTheSamePlaceTests
    {
        [TestMethod]
        public void GivenArrayLengthAndSteps_GetNumberOfWays_ShouldReturnCorrectNumberOfWays()
        {
            var steps = 4; var arrLen = 2;

            var result = GetNumberOfWays(steps, arrLen);

            Assert.IsTrue(result == 8);
        }

        private int GetNumberOfWays(int steps, int arrLen)
        {
            var dp = GenerateDP(steps, arrLen);

            InitializeDP(dp);
            CreateDP(dp, arrLen);

            return dp[steps][0];
        }

        private void CreateDP(int[][] dp, int arrLen)
        {

            for (int i = 1; i < dp.Length; i++)
            {
                dp[i][0] = dp[i - 1][0] + dp[i - 1][1];
                dp[i][arrLen - 1] = dp[i - 1][arrLen - 2] + dp[i - 1][arrLen - 1];

                for (var j = i; j < dp[0].Length - 1; j++)
                {
                    dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j] + dp[i - 1][j + 1];
                }
            }
        }

        private void InitializeDP(int[][] dp)
        {
            dp[0][0] = 1;
        }

        private int[][] GenerateDP(int steps, int arrLen)
        {
            var dp = new int[steps + 1][];

            for (int i = 0; i < steps + 1; i++)
            {
                dp[i] = new int[arrLen];
            }

            return dp;
        }
    }
}
