using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC221_MaximalSquare
{
    [TestClass]
    public class MaximalSquareTests
    {
        [TestMethod]
        public void GivenInputGrid_FindMaximalSquare_ShouldReturnMaximalSquareArea()
        {
            var mat = new int[][] { new int[] { 1, 0, 1, 0, 0 }, new int[] { 1, 0, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, }, new int[] { 1, 0, 0, 1, 0 } };

            var area = FindMaximalSquare(mat);

            Assert.IsTrue(area == 4);
        }

        private int FindMaximalSquare(int[][] mat)
        {
            var maxSide = 0;
            var dp = GenerateDP(mat);

            var row = dp.Length;
            var col = dp[0].Length;
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    if (mat[i - 1][j - 1] == 0)
                    {
                        dp[i][j] = 0;
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] == dp[i][j - 1] && dp[i][j - 1] == dp[i - 1][j - 1]  ? dp[i - 1][j - 1] + 1 : 1;
                        if (dp[i][j] > maxSide)
                        {
                            maxSide = dp[i][j];
                        }
                    }
                }
            }

            return maxSide * maxSide;
        }

        private int[][] GenerateDP(int[][] mat)
        {
            var row = mat.Length + 1; 
            var col = mat[0].Length + 1;
            var dp = new int[row][];
            for (int i = 0; i < row; i++)
            {
                dp[i] = new int[col];
            }

            return dp;
        }
    }
}
