using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC463_FindPerimeter
{
    [TestClass]
    public class FindPerimeterTests
    {
        [TestMethod]
        public void GivenIsland_FindPerimeter_ShouldReturnCorrectPerimeter()
        {
            var input = new int[][] { new int[] { 0, 1, 0, 0 },
                                      new int[] { 1, 1, 1, 0 },
                                      new int[] { 0, 1, 0, 0 },
                                      new int[] { 1, 1, 0, 0 }};


            var result = FindIslandPerimeter(input);

            Assert.IsTrue(result == 16);
        }

        private int FindIslandPerimeter(int[][] input)
        {
            var row = input.Length;
            var col = input[0].Length;

            var visited = GenerateVisited(row, col);
            var startPoint = FindStartPoint(input);

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(startPoint);

            var perimeter = 0;

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                visited[item.Item1][item.Item2] = true;
                var neighbors = GetNeighbors(item.Item1, item.Item2, input);
                perimeter += 4 - neighbors.Count;

                foreach (var neighbor in neighbors)
                {
                    if (!visited[neighbor.Item1][neighbor.Item2])
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return perimeter;
        }

        private List<Tuple<int, int>> GetNeighbors(int row, int col, int[][] input)
        {
            var neighbors = new List<Tuple<int, int>>();

            if (CanMoveTo(row - 1, col, input))
            {
                neighbors.Add(new Tuple<int, int>(row - 1, col));
            }

            if (CanMoveTo(row + 1, col, input))
            {
                neighbors.Add(new Tuple<int, int>(row + 1, col));
            }

            if (CanMoveTo(row, col - 1, input))
            {
                neighbors.Add(new Tuple<int, int>(row, col - 1));
            }

            if (CanMoveTo(row, col + 1, input))
            {
                neighbors.Add(new Tuple<int, int>(row, col + 1));
            }

            return neighbors;
        }

        private bool CanMoveTo(int row, int col, int[][] input)
        {
            return row >= 0 && col >= 0 && row < input.Length && col < input[0].Length && input[row][col] != 0;
        }

        private Tuple<int, int> FindStartPoint(int[][] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (input[i][j] == 1)
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }

            return new Tuple<int, int>(int.MinValue, int.MinValue);
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
    }
}
