using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC305_NumberOfIslands
{
    [TestClass]
    public class NumberOfIslandsIITests
    {
        [TestMethod]
        public void GivenGridAndListOfCoord_NumberOfIslands_ShouldReturnCorrectNumber()
        {
            var coordList = new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 } };
            var m = 3; var n = 3;

            var result = GetNumberOfIslands(m, n, coordList);

            Assert.IsTrue(result == 3);
        }

        private int GetNumberOfIslands(int m, int n, int[][] coordList)
        {
            var numIslands = 0;
            var root = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            var grid = GenerateGrid(m, n);

            foreach (var coord in coordList)
            {
                grid[coord[0]][coord[1]] = 1;
                var neighbors = Find(coord[0], coord[1], grid);
                root.Add(new Tuple<int, int>(coord[0], coord[1]), new Tuple<int, int>(coord[0], coord[1]));
                if (neighbors.Count == 0)
                {
                    numIslands++;
                }
                else
                {
                    var disjointSetNumber = GetNumDisjointSet(neighbors, root);
                    numIslands -= (disjointSetNumber - 1);
                    Union(coord[0], coord[1], grid, root);
                }
            }

            return numIslands;
        }

        private void Union(int row, int col, int[][] grid, Dictionary<Tuple<int, int>, Tuple<int, int>> root)
        {
            var visited = new HashSet<Tuple<int, int>>();

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(row, col));

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                root[current] = new Tuple<int, int>(row, col);
                visited.Add(current);
                var neighbors = GetNeighbors(current.Item1, current.Item2, grid);

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        private int GetNumDisjointSet(List<Tuple<int, int>> neighbors, Dictionary<Tuple<int, int>, Tuple<int, int>> root)
        {
            var hashSet = new HashSet<Tuple<int, int>>();

            foreach (var neighbor in neighbors)
            {
                hashSet.Add(root[neighbor]);
            }
            return hashSet.Count;
        }

        private List<Tuple<int, int>> Find(int row, int col, int[][] grid)
        {
            return GetNeighbors(row, col, grid);
        }

        private List<Tuple<int, int>> GetNeighbors(int row, int col, int[][] grid)
        {
            var neighbors = new List<Tuple<int, int>>();

            if (CanMoveTo(row - 1, col, grid))
            {
                neighbors.Add(new Tuple<int, int>(row - 1, col));
            }
            if (CanMoveTo(row + 1, col, grid))
            {
                neighbors.Add(new Tuple<int, int>(row + 1, col));
            }
            if (CanMoveTo(row, col - 1, grid))
            {
                neighbors.Add(new Tuple<int, int>(row, col - 1));
            }
            if (CanMoveTo(row, col + 1, grid))
            {
                neighbors.Add(new Tuple<int, int>(row, col + 1));
            }
            return neighbors;
        }

        private bool CanMoveTo(int row, int col, int[][] grid)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == 1;
        }

        private int[][] GenerateGrid(int m, int n)
        {
            var grid = new int[m][];
            for (int i = 0; i < m; i++)
            {
                grid[i] = new int[n];
            }

            return grid;
        }
    }
}
