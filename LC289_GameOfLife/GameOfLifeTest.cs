using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC289_GameOfLife
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void GivenGrid_GetNextState_ShouldReturnNextState()
        {
            var grid = new int[][] { new int[]  { 0, 1, 0},
                                      new int[] { 0, 0, 1},
                                      new int[] { 1, 1, 1},
                                      new int[] { 0, 0, 0}};

            GetNextState(grid);

            Assert.IsTrue(grid[0].SequenceEqual(new int[] { 0, 0, 0}));
            Assert.IsTrue(grid[1].SequenceEqual(new int[] { 1, 0, 1 }));
            Assert.IsTrue(grid[2].SequenceEqual(new int[] { 0, 1, 1 }));
            Assert.IsTrue(grid[3].SequenceEqual(new int[] { 0, 1, 0 }));
        }

        private void GetNextState(int[][] grid)
        {
            var shouldFlip = new Queue<Tuple<int, int>>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (ShouldFlip(i, j, grid))
                    {
                        shouldFlip.Enqueue(new Tuple<int, int>(i, j));
                    }

                    TryFlip(i, shouldFlip, grid);
                }
            }

            FlipAll(shouldFlip, grid);
        }

        private void FlipAll(Queue<Tuple<int, int>> shouldFlip, int[][] grid)
        {
            while (shouldFlip.Count != 0)
            {
                var target = shouldFlip.Dequeue();

                grid[target.Item1][target.Item2] ^= 1;
            }
        }

        private void TryFlip(int row, Queue<Tuple<int, int>> shouldFlip, int[][] grid)
        {
            if (shouldFlip.Count > 0)
            {
                var top = shouldFlip.First();

                if (Math.Abs(row - top.Item1) > 1)
                {
                    grid[top.Item1][top.Item2] ^= 1;
                    shouldFlip.Dequeue();
                }
            }
        }

        private bool ShouldFlip(int row, int col, int[][] grid)
        {
            var neighbors = GetNeighbors(row, col, grid);
            var livingCount = 0;

            foreach (var neighbor in neighbors)
            {
                if (grid[neighbor.Item1][neighbor.Item2] == 1)
                {
                    livingCount++;
                }
            }

            if (grid[row][col] == 1 && (livingCount < 2 || livingCount > 3))
            {
                return true;
            }

            if (grid[row][col] == 0 && livingCount == 3)
            {
                return true;
            }

            return false;
        }

        private List<Tuple<int, int>> GetNeighbors(int row, int col, int[][] grid)
        {
            var neighbors = new List<Tuple<int, int>>();

            if (CanMoveTo(row - 1, col, grid)) neighbors.Add(new Tuple<int, int>(row - 1, col));
            if (CanMoveTo(row + 1, col, grid)) neighbors.Add(new Tuple<int, int>(row + 1, col));
            if (CanMoveTo(row, col - 1, grid)) neighbors.Add(new Tuple<int, int>(row, col - 1));
            if (CanMoveTo(row, col + 1, grid)) neighbors.Add(new Tuple<int, int>(row, col + 1));
            if (CanMoveTo(row - 1, col - 1, grid)) neighbors.Add(new Tuple<int, int>(row - 1, col - 1));
            if (CanMoveTo(row - 1, col + 1, grid)) neighbors.Add(new Tuple<int, int>(row - 1, col + 1));
            if (CanMoveTo(row + 1, col - 1, grid)) neighbors.Add(new Tuple<int, int>(row + 1, col - 1));
            if (CanMoveTo(row + 1, col + 1, grid)) neighbors.Add(new Tuple<int, int>(row + 1, col + 1));

            return neighbors;
        }

        private bool CanMoveTo(int row, int col, int[][] grid)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length;
        }
    }
}
