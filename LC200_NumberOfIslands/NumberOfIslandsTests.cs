using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC200_NumberOfIslands
{
    [TestClass]
    public class NumberOfIslandsTests
    {
        [TestMethod]
        public void GivenGridMatrix_FindNumberOfIslands_ShouldReturnNumberOfIslands()
        {
            var grid = new int[][] { new int[] { 1, 1, 0, 0, 0 }, new int[] { 1, 1, 0, 0, 0 }, new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 0, 1, 1 } };

            int result = FindNumberOfIslands(grid);

            Assert.IsTrue(result == 3);
        }

        private int FindNumberOfIslands(int[][] grid)
        {
            var number = 0;

            var visited = GenerateVisitedGrid(grid);

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1 && visited[i][j] == 0)
                    {
                        number++;
                        MapIsland(grid, visited, i, j);
                    }
                }
            }

            return number;
        }

        private int[][] GenerateVisitedGrid(int[][] grid)
        {
            var visited = new int[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                visited[i] = new int[grid[0].Length];
            }

            return visited;
        }

        private void MapIsland(int[][] grid, int[][] visited, int row, int col)
        {
            if (visited[row][col] == 1 || grid[row][col] != 1)
            {
                return;
            }

            visited[row][col] = 1;
            var neighbors = GetNeighbors(grid, row, col);

            foreach (var neighbor in neighbors)
            {
                MapIsland(grid, visited, neighbor.Item1, neighbor.Item2);
            }
        }

        private List<Tuple<int, int>> GetNeighbors(int[][] grid, int row, int col)
        {
            var neighbors = new List<Tuple<int, int>>();
            if (row != 0)
            {
                neighbors.Add(new Tuple<int, int>(row - 1, col));
            }

            if (row != grid.Length - 1)
            {
                neighbors.Add(new Tuple<int, int>(row + 1, col));
            }

            if (col != 0)
            {
                neighbors.Add(new Tuple<int, int>(row, col - 1));
            }

            if (col != grid[0].Length - 1)
            {
                neighbors.Add(new Tuple<int, int>(row, col + 1));
            }

            return neighbors;
        }
    }
}
