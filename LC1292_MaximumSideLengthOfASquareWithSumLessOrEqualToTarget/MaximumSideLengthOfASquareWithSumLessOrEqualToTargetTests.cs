using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1292_MaximumSideLengthOfASquareWithSumLessOrEqualToTarget
{
    [TestClass]
    public class MaximumSideLengthOfASquareWithSumLessOrEqualToTargetTests
    {
        [TestMethod]
        public void GivenGridAndThreshold_GetMaximumSquareLength_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 1, 1, 3, 2, 4, 3, 2 },
                                     new int[] { 1, 1, 3, 2, 4, 3, 2 },
                                     new int[] { 1, 1, 3, 2, 4, 3, 2 }};

            var target = 4;

            var result = GetMaximumSquareSideLength(grid, target);

            Assert.IsTrue(result == 2);
        }

        private int GetMaximumSquareSideLength(int[][] grid, int target)
        {
            var result = 0;

            var prefixSumPerRow = GetPrefixSumPerRow(grid);
            var prefixSumPerCol = GetPrefixSumPerCol(grid);

            var squareSums = GetSquareSum(prefixSumPerRow, prefixSumPerCol, grid);

            foreach (var sum in squareSums)
            {
                if (sum.Value <= target)
                {
                    result = Math.Max(sum.Key.length, result);
                }
            }

            return result;
        }

        private Dictionary<(int endRow, int endCol, int length), int> GetSquareSum(int[][] prefixSumPerRow, int[][] prefixSumPerCol, int[][] grid)
        {
            var result = new Dictionary<(int endRow, int endCol, int length), int>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    result.Add((i, j, 1), grid[i][j]);
                }
            }

            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[0].Length; j++)
                {   
                    var smaller = i < j ? i : j;
                    var maxLength = smaller + 1;

                    for (int length = 2; length <= maxLength; length++)
                    {
                        var prev = length - 1;
                        result.Add((i, j, length), result[(i - 1, j - 1, prev)] +
                            (prefixSumPerRow[i + 1][j + 1] - prefixSumPerRow[i + 1][j + 1 - length]) +
                            (prefixSumPerCol[i + 1][j + 1] - prefixSumPerCol[i + 1 - length][j + 1]) -
                            grid[i][j]);
                    }
                }
            }

            return result;
        }

        private int[][] GetPrefixSumPerCol(int[][] grid)
        {
            var dp = GenerateDP(grid);

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    dp[i][j] = dp[i - 1][j] + grid[i - 1][j - 1];
                }
            }
            return dp;
        }

        private int[][] GenerateDP(int[][] grid)
        {
            var dp = new int[grid.Length + 1][];
            for (int i = 0; i < grid.Length + 1; i++)
            {
                dp[i] = new int[grid[0].Length + 1];
            }
            return dp;
        }

        private int[][] GetPrefixSumPerRow(int[][] grid)
        {
            var dp = GenerateDP(grid);

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    dp[i][j] = dp[i][j - 1] + grid[i - 1][j - 1];
                }
            }

            return dp;
        }
    }
}
