using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC505_MazeII
{
    [TestClass]
    public class MazeIITests
    {
        [TestMethod]
        public void GivenMazeMatrix_GetShortestDistance_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 0, 0, 1, 0, 0},
                                     new int[] { 0, 0, 0, 0, 0},
                                     new int[] { 0, 0, 0, 1, 0},
                                     new int[] { 1, 1, 0, 1, 1},
                                     new int[] { 0, 0, 0, 0, 0}};

            var distance = GetShortestDistance(grid, 0, 4, 4, 4);

            Assert.IsTrue(distance == 12);
        }

        private int GetShortestDistance(int[][] grid, int startRow, int startCol, int endRow, int endCol)
        {
            var visited = new Dictionary<(int row, int col), int>();
            var queue = new Queue<(int row, int col, int distance)>();
            queue.Enqueue((startRow, startCol, 0));


            var minDistance = -1;
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                if (!visited.ContainsKey((top.row, top.col)))
                {
                    visited.Add((top.row, top.col), top.distance);
                }
                else
                {
                    if (visited[(top.row, top.col)] <= top.distance)
                    {
                        continue;
                    }
                    else
                    {
                        visited[(top.row, top.col)] = top.distance;
                    }
                }

                if (top.row == endRow && top.col == endCol)
                {
                    minDistance = minDistance == -1 ? top.distance : Math.Min(minDistance, top.distance);
                    continue;
                }

                Go(top, grid, queue);
            }

            return minDistance;
        }

        private void Go((int row, int col, int distance) current, int[][] grid, Queue<(int row, int col, int distance)> queue)
        {
            var destination = GetUp(current, grid);
            if (destination.row != current.row)
            {
                queue.Enqueue(destination);
            }

            destination = GetDown(current, grid);
            if (destination.row != current.row)
            {
                queue.Enqueue(destination);
            }

            destination = GetLeft(current, grid);
            if (destination.col != current.col)
            {
                queue.Enqueue(destination);
            }

            destination = GetRight(current, grid);
            if (destination.col != current.col)
            {
                queue.Enqueue(destination);
            }
        }

        private (int row, int col, int distance) GetRight((int row, int col, int distance) current, int[][] grid)
        {
            while (CanGo(current.row, current.col + 1, grid))
            {
                current.col++; current.distance++;
            }

            return current;
        }

        private (int row, int col, int distance) GetLeft((int row, int col, int distance) current, int[][] grid)
        {
            while (CanGo(current.row, current.col - 1, grid))
            {
                current.col--; current.distance++;
            }

            return current;
        }

        private (int row, int col, int distance) GetDown((int row, int col, int distance) current, int[][] grid)
        {
            while (CanGo(current.row + 1, current.col, grid))
            {
                current.row++; current.distance++;
            }

            return current;
        }

        private bool CanGo(int row, int col, int[][] grid)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] != 1;
        }

        private (int row, int col, int distance) GetUp((int row, int col, int distance) current, int[][] grid)
        {
            while (CanGo(current.row - 1, current.col, grid))
            {
                current.row--; current.distance++;
            }

            return current;
        }
    }
}
