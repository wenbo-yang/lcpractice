using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1293_ShortestPathWithObstaclesEliminations
{
    [TestClass]
    public class ShortestPathWithObstaclesEliminationsTests
    {
        [TestMethod]
        public void GivenGridAndAndNumberOfEliminations_GetShortestPath_ShouldReturnShortestPathLength()
        {
            var grid = new int[][] { new int[] { 0, 0, 0},
                                     new int[] { 1, 1, 0},
                                     new int[] { 0, 0, 0},
                                     new int[] { 0, 1, 1},
                                     new int[] { 0, 0, 0}};
            var k = 1;
            var result = GetShortestPath(grid, k);

            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void GivenInvalidGridAndAndNumberOfEliminations_GetShortestPath_ShouldReturnInvalidLength()
        {
            var grid = new int[][] { new int[] { 0, 0, 0},
                                     new int[] { 1, 1, 0},
                                     new int[] { 1, 1, 1},
                                     new int[] { 0, 1, 1},
                                     new int[] { 0, 0, 0}};
            var k = 1;
            var result = GetShortestPath(grid, k);

            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void GivenValidWindyGridAndAndNumberOfEliminations_GetShortestPath_ShouldReturnInvalidLength()
        {
            var grid = new int[][] { new int[] { 0, 1, 0, 0},
                                     new int[] { 1, 1, 1, 0},
                                     new int[] { 1, 1, 0, 1},
                                     new int[] { 1, 0, 0, 1},
                                     new int[] { 0, 0, 1, 0},
                                     new int[] { 0, 0, 0, 0}};
            var k = 2;
            var result = GetShortestPath(grid, k);

            Assert.IsTrue(result == 10);
        }

        private int GetShortestPath(int[][] grid, int k)
        {
            var result = -1;

            var visited = new HashSet<(int row, int col, int n)>();

            var queue = new Queue<(int row, int col, int n, int length)>();

            queue.Enqueue((0, 0, 0, 0));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (top.row == grid.Length - 1 && top.col == grid[0].Length - 1)
                {
                    result = top.length;
                    break;
                }

                visited.Add((top.row, top.col, top.n));

                var children = GetNeigbhors(grid, top, k, visited);

                foreach (var child in children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private List<(int row, int col, int n, int length)> GetNeigbhors(int[][] grid, (int row, int col, int n, int length) top, int k, HashSet<(int row, int col, int n)> visited)
        {
            var length = top.length + 1;
            var neighbors = new List<(int row, int col, int n, int length)>();

            if (CanMoveTo(top.row - 1, top.col, top.n, k, grid, visited))
            {
                neighbors.Add((top.row - 1, top.col, top.n + grid[top.row - 1][top.col], length));
            }

            if (CanMoveTo(top.row + 1, top.col, top.n, k, grid, visited))
            {
                neighbors.Add((top.row + 1, top.col, top.n + grid[top.row + 1][top.col], length));
            }

            if (CanMoveTo(top.row, top.col - 1, top.n, k, grid, visited))
            {
                neighbors.Add((top.row, top.col - 1, top.n + grid[top.row][top.col - 1], length));
            }

            if (CanMoveTo(top.row, top.col + 1, top.n, k, grid, visited))
            {
                neighbors.Add((top.row, top.col + 1, top.n + grid[top.row][top.col + 1], length));
            }

            return neighbors;
        }

        private bool CanMoveTo(int row, int col, int n, int k, int[][] grid, HashSet<(int row, int col, int n)> visited)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && (grid[row][col] == 1 ? n < k : true) && !visited.Contains((row, col, n));
        }
    }
}
