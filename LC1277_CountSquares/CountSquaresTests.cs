using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1277_CountSquares
{
    [TestClass]
    public class CountSquaresTests
    {
        [TestMethod]
        public void GivenGrid_CountSquares_ShouldReturnCorrectNumberOfSquares()
        {
            var grid = new int[][] { new int[] { 0, 1, 1, 1},
                                     new int[] { 1, 1, 1, 1},
                                     new int[] { 0, 1, 1, 1}};


            var result = CountSquares(grid);

            Assert.IsTrue(result == 15);
        }

        [TestMethod]
        public void GivenAnotherGrid_CountSquares_ShouldReturnCorrectNumberOfSquares()
        {
            var grid = new int[][] { new int[] { 1, 0, 1},
                                     new int[] { 1, 1, 0},
                                     new int[] { 1, 1, 0}};


            var result = CountSquares(grid);

            Assert.IsTrue(result == 7);
        }

        private int CountSquares(int[][] grid)
        {
            var dp = InitializeDP(grid);
            var count = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    dp[i][j] = grid[i - 1][j - 1] == 0 ? 0 : Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + 1;

                    count += dp[i][j];
                }
            }

            return count;
        }

        private int[][] InitializeDP(int[][] grid)
        {
            var dp = new int[grid.Length + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[0].Length + 1]; 
            }

            return dp;
        }
    }
}
