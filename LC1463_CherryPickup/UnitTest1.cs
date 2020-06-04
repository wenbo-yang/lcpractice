using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1463_CherryPickup
{
    [TestClass]
    public class CherryPickupTests
    {
        [TestMethod]
        public void GivenArrayOfCherries_CherryPickup_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 3, 1, 1 }, new int[] { 2, 5, 1 }, new int[] { 1, 5, 5 }, new int[] { 2, 1, 1 } };
            var result = CherryPickup(grid);

            Assert.IsTrue(result == 24);
        }

        private int CherryPickup(int[][] grid)
        {
            var dpR1 = GenerateDP(grid, true);
            var dpR2 = GenerateDP(grid, false);

            var backTraceR1 = new Dictionary<(int r, int c), (int r, int c)>() { { (0, 0), (-1, -1) } };
            var queue = new Queue<(int r, int c)>();
            queue.Enqueue((0, 0));
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                var children = GetChildren(top, grid);

                foreach (var child in children)
                {
                    var row = child.r;
                    var col = child.c;
                    var parent = GetParent(child, grid, dpR1);
                    dpR1[row + 1][col + 1] = dpR1[parent.r][parent.c] + grid[row][col];

                    backTraceR1.Add((child), (parent));
                }
            }

            CleanUpGridAfterR1Pickup(grid, backTraceR1, dpR1);

            queue = new Queue<(int r, int c)>();
            queue.Enqueue((0, grid.Length - 1));
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                var children = GetChildren(top, grid);

                foreach (var child in children)
                {
                    var row = child.r;
                    var col = child.c;
                    var parent = GetParent(child, grid, dpR2);
                    dpR2[row + 1][col + 1] = dpR2[parent.r][parent.c] + grid[row][col];
                }
            }

            return dpR1[grid.Length].Max() + dpR2[grid.Length].Max();
        }

        private void CleanUpGridAfterR1Pickup(int[][] grid, Dictionary<(int r, int c), (int r, int c)> backTraceR1, int[][] dpR1)
        {
            throw new NotImplementedException();
        }

        private (int r, int c) GetParent((int r, int c) child, int[][] grid, int[][] dp)
        {
            var parentValue = Math.Max(Math.Max(dp[child.r][child.c],
                                                dp[child.r][child.c + 1]),
                                                dp[child.r][child.c + 2]);

            if (parentValue == dp[child.r][child.c])
            {
                return (child.r - 1, child.c - 1);
            }
            else if (parentValue == dp[child.r][child.c + 1])
            {
                return (child.r - 1, child.c);
            }

            return (child.r - 1, child.c + 1);
        }

        private List<(int r, int c)> GetChildren((int r, int c) top, int[][] grid)
        {
            throw new NotImplementedException();
        }

        private int[][] GenerateDP(int[][] grid, bool isR1)
        {
            var dp = new int[grid.Length + 2][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[grid[0].Length + 2];
            }

            if (isR1)
            {
                dp[1][1] = grid[0][0];
            }
            else
            {
                dp[1][grid[0].Length - 1] = grid[0][grid[0].Length - 1];
            }

            return dp;
        }
    }
}
