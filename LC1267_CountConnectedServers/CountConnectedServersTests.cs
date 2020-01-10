using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1267_CountConnectedServers
{
    [TestClass]
    public class CountConnectedServersTests
    {
        [TestMethod]
        public void GivenGrid_GetConnectedServers_ShouldReturnBiggestIsland()
        {
            var grid = new int[][] { new int[] { 1, 1, 0, 0 },
                                     new int[] { 0, 0, 1, 0 },
                                     new int[] { 0, 0, 1, 0 },
                                     new int[] { 0, 0, 0, 1 }};

            var result = GetConnectedServers(grid);

            Assert.IsTrue(result == 4);

        }

        private int GetConnectedServers(int[][] grid)
        {
            var visited = GenerateVisited(grid);

            var result = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (!visited[i][j] && grid[i][j] == 1)
                    {
                        var size = MapIsland(i, j, grid, visited);

                        result = size > 1 ? result + size : result;
                    }
                }
            }

            return result;

        }

        private int MapIsland(int startRow, int startCol, int[][] grid, bool[][] visited)
        {
            var size = 0;

            var queue = new Queue<(int row, int col)>();

            queue.Enqueue((startRow, startCol));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                visited[top.row][top.col] = true;
                size++;
                var neighbors = GetNeighbors(top.row, top.col, grid, visited);

                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue((neighbor.row, neighbor.col));
                }
            }

            return size;
        }

        private List<(int row, int col)> GetNeighbors(int row, int col, int[][] grid, bool[][] visited)
        {
            var result = new List<(int row, int col)>();

            if (CanMoveTo(row - 1, col, grid, visited))
            {
                result.Add((row - 1, col));
            }
            if (CanMoveTo(row + 1, col, grid, visited))
            {
                result.Add((row + 1, col));
            }
            if (CanMoveTo(row, col - 1, grid, visited))
            {
                result.Add((row, col - 1));
            }
            if (CanMoveTo(row, col + 1, grid, visited))
            {
                result.Add((row, col + 1));
            }

            return result;
        }

        private bool CanMoveTo(int row, int col, int[][] grid, bool[][] visited)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == 1 && !visited[row][col];
        }

        private bool[][] GenerateVisited(int[][] grid)
        {
            var visited = new bool[grid.Length][];

            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = new bool[grid[0].Length];
            }

            return visited;
        }
    }
}
