using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC931_MinimumFallingPathSum
{
    [TestClass]
    // Lc 1289 is also here
    public class MinimumFallingPathSumTests
    {
        [TestMethod]
        public void GivenGrid_GetMinimumPathSum_ShouldMinimumSum()
        {
            var grid = new int[][] { new int[] {1, 2, 3 },
                                     new int[] {4, 5, 6 },
                                     new int[] {7, 8, 9 }};

            var result = GetMinimumPathSum(grid);

            Assert.IsTrue(result == 12);
        }

        [TestMethod]
        public void GivenGrid_GetMinimumPathSumZigZag_ShouldMinimumSum()
        {
            var grid = new int[][] { new int[] {1, 2, 3 },
                                     new int[] {4, 5, 6 },
                                     new int[] {7, 8, 9 }};

            var result = GetMinimumPathSumZigZag(grid);

            Assert.IsTrue(result == 13);
        }

        private int GetMinimumPathSum(int[][] grid)
        {
            var dp = GenereteAndInitializeDP(grid);
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length - 1; j++)
                {
                    dp[i][j] = Math.Min(Math.Min(dp[i - 1][j - 1], dp[i - 1][j + 1]), dp[i - 1][j]) + grid[i - 1][j - 1];
                }
            }

            return dp[dp.Length - 1].Min();
        }

        private int GetMinimumPathSumZigZag(int[][] grid)
        {
            var dp = GenereteAndInitializeDP(grid);
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length - 1; j++)
                {
                    dp[i][j] = Math.Min(dp[i - 1][j - 1], dp[i - 1][j + 1]) + grid[i - 1][j - 1];
                }
            }

            return dp[dp.Length - 1].Min();
        }

        private int[][] GenereteAndInitializeDP(int[][] grid)
        {
            var dp = new int[grid.Length + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[0].Length + 2];
                dp[i][0] = int.MaxValue;
                dp[i][dp[i].Length - 1] = int.MaxValue; 
            }

            return dp;
        }
    }
}
