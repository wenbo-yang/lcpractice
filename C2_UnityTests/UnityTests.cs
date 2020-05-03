using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C2_UnityTests
{
    [TestClass]
    public class UnityTests
    {
        [TestMethod]
        public void Given_SomeQuestion_SolutionShouldDoSomething()
        {
            var arr = new int[] { 1, 3, 4, 2, 2, 2, 1, 1, 2 };

            var result = CanBalanceLoad(arr);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Given_AnotherQuestion_SolutionShouldDoSomething()
        {
            var grid = new int[][] { new int[] { 5, 4, 4 },
                                    new int[] { 4, 3, 4},
                                    new int[] { 3, 2, 4},
                                    new int[] { 2, 2, 2},
                                    new int[] { 3, 3, 4},
                                    new int[] { 1, 4, 4},
                                    new int[] { 4, 1, 1}};
            var result = GetNumberOfCountries(grid);

            Assert.IsTrue(result == 11);
        }

        private int GetNumberOfCountries(int[][] grid)
        {
            var row = grid.Length;
            var col = grid[0].Length;

            var visited = GenerateVisited(row, col);
            var numCountries = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!visited[i][j])
                    {
                        MapCountry(grid, visited, i, j);
                        numCountries++;
                    }
                }
            }

            return numCountries;
        }

        private void MapCountry(int[][] grid, bool[][] visited, int r, int c)
        {
            var targetValue = grid[r][c];
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(r, c));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                visited[top.Item1][top.Item2] = true;

                var neighbors = GetNeighbors(grid, visited, targetValue, top.Item1, top.Item2);

                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        private List<Tuple<int, int>> GetNeighbors(int[][] grid, bool[][] visited, int targetValue, int row, int col)
        {
            var neighbors = new List<Tuple<int, int>>();

            if (CanMoveTo(grid, visited, targetValue, row - 1, col)) // up
            {
                neighbors.Add(new Tuple<int, int>(row - 1, col));
            }

            if (CanMoveTo(grid, visited, targetValue, row + 1, col)) //down
            {
                neighbors.Add(new Tuple<int, int>(row + 1, col));
            }

            if (CanMoveTo(grid, visited, targetValue, row, col - 1)) // left 
            {
                neighbors.Add(new Tuple<int, int>(row, col - 1));
            }

            if (CanMoveTo(grid, visited, targetValue, row, col + 1)) // right
            {
                neighbors.Add(new Tuple<int, int>(row, col + 1));
            }

            return neighbors;
        }

        private bool CanMoveTo(int[][] grid, bool[][] visited, int targetValue, int row, int col)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == targetValue &&!visited[row][col];
        }

        private bool[][] GenerateVisited(int row, int col)
        {
            var visited = new bool[row][];
            for (int i = 0; i < row; i++)
            {
                visited[i] = new bool[col];
            }

            return visited;
        }

        private bool CanBalanceLoad(int[] arr)
        {
            var leftIndex = 0;
            var rightIndex = arr.Length - 1;

            var x = 0;
            var z = 0;
            var y = arr.Sum() - arr[0] - arr[arr.Length - 1];

            while (leftIndex + 1 != rightIndex)
            {
                if (x == y && x == z)
                {
                    return true;
                }

                if (x > y || z > y) // this happens we have an invalid scenario
                {
                    return false;
                }

                if (x > z)
                {
                    rightIndex--;
                    z += arr[rightIndex + 1];
                    y -= arr[rightIndex];
                }
                else
                {
                    leftIndex++;
                    x += arr[leftIndex - 1];
                    y -= arr[leftIndex];
                }
            }

            return false;
        }
    }
}
