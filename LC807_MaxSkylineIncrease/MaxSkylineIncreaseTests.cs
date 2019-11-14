using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC807_MaxSkylineIncrease
{
    [TestClass]
    public class MaxSkylineIncreaseTests
    {
        [TestMethod]
        public void GivenGrid_GetMaxIncrease_ShouldReturnCorrectNumber()
        {
            var grid = new int[][] { new int[] { 3, 0, 8, 4},
                                     new int[] { 2, 4, 5, 7},
                                     new int[] { 9, 2, 6, 3},
                                     new int[] { 0, 3, 1, 0}};

            var result = GetMaxSkylineIncrease(grid);

            Assert.IsTrue(result == 35);
        }

        private int GetMaxSkylineIncrease(int[][] grid)
        {
            var maxRowHeight = new int[grid.Length];
            var maxColHeight = new int[grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    maxRowHeight[i] = Math.Max(maxRowHeight[i], grid[i][j]);
                    maxColHeight[j] = Math.Max(maxColHeight[j], grid[i][j]);
                }
            }

            var result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    var canIncreaseUpTo = Math.Min(maxRowHeight[i], maxColHeight[j]);

                    result += Math.Max(0, canIncreaseUpTo - grid[i][j]);
                }
            }

            return result;
        }
    }
}
