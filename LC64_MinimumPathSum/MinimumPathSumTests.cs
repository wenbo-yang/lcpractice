using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC64_MinimumPathSum
{
    [TestClass]
    public class MinimumPathSumTests
    {
        [TestMethod]
        public void GivenMat_MinimumPathSum_ShouldReturnCorrectResult()
        {
            var mat = new int[][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };

            int result = MinimumPathSum(mat);

            Assert.IsTrue(result == 7);
        }

        private int MinimumPathSum(int[][] mat)
        {
            var row = mat.Length;
            var col = mat[0].Length;
            int[][] dp = GenerateDP(row, col);
            InitializeDP(dp);

            for(int i = 1; i<= row; i++)
            {
                for (int j = 1; j <= col; j++)
                {
                    dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + mat[i - 1][j - 1];
                }
            }

            return dp[row][col];
        }

        private void InitializeDP(int[][] dp)
        {
            for (int i = 2; i < dp.Length; i++)
            {
                dp[i][0] = int.MaxValue;
            }

            for (int j = 2; j < dp.Length; j++)
            {
                dp[0][j] = int.MaxValue;
            }
        }

        private int[][] GenerateDP(int row, int col)
        {
            var dp = new int[row + 1][];

            for (int i = 0; i < row + 1; i++)
            {
                dp[i] = new int[col + 1];
            }

            return dp;
        }
    }
}
