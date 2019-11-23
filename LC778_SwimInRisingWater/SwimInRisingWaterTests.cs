using System;
using System.Collections.Generic;
using CommonUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC778_SwimInRisingWater
{
    [TestClass]
    public class SwimInRisingWaterTests
    {
        [TestMethod]
        public void GivenGridWithHeights_GetSwimTime_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 0, 2 }, new int[] { 1, 3 } };

            var result = GetSwimTimeBruteForce(grid);

            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void GivenBiggerGridWithHeights_GetSwimTime_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 0, 1, 2, 3, 4 },
                                     new int[] { 24, 23, 22, 21, 5},
                                     new int[] { 12, 13, 14, 15, 16},
                                     new int[] { 11, 17, 18, 19, 20},
                                     new int[] { 10, 9, 8, 7, 6},
            };

            var result = GetSwimTimeBruteForce(grid);

            Assert.IsTrue(result == 16);
        }

        [TestMethod]
        public void GivenBiggerGridWithHeights_GetSwimTimeMinHeap_ShouldReturnCorrectAnswer()
        {
            var grid = new int[][] { new int[] { 0, 1, 2, 3, 4 },
                                     new int[] { 24, 23, 22, 21, 5},
                                     new int[] { 12, 13, 14, 15, 16},
                                     new int[] { 11, 17, 18, 19, 20},
                                     new int[] { 10, 9, 8, 7, 6},
            };

            var result = GetSwimTimeMinHeap(grid);

            Assert.IsTrue(result == 16);
        }

        private int GetSwimTimeMinHeap(int[][] grid)
        {
            var minHeap = new MinHeap<Tuple<int, Tuple<int, int>>>();
            var visited = new HashSet<Tuple<int, int>>();

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 0));

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                visited.Add(top);

                if (top.Item1 == grid.Length - 1 && top.Item2 == grid.Length - 1)
                {
                    break;
                }

                var neighbors = GetNeighbors(top.Item1, top.Item2, grid);
                var currentHeight = grid[top.Item1][top.Item2];
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        var neighborHeight = grid[neighbor.Item1][neighbor.Item2];
                        if (currentHeight >= neighborHeight)
                        {
                            grid[neighbor.Item1][neighbor.Item2] = currentHeight;
                            queue.Enqueue(neighbor);
                        }
                        else
                        {
                            minHeap.Add(new Tuple<int, Tuple<int, int>>(grid[neighbor.Item1][neighbor.Item2], neighbor));
                        }
                    }
                }

                if (queue.Count == 0)
                {
                    var minNeighbor = minHeap.Pop();
                    queue.Enqueue(minNeighbor.Item2);
                }
            }

            return grid[grid.Length - 1][grid.Length - 1];
        }

        private int GetSwimTimeBruteForce(int[][] grid)
        {
            var n = grid.Length;
            var minWait = grid[n - 1][n - 1];
            var maxWait = n*n - 1;

            while (minWait < maxWait)
            {
                var pivot = (maxWait + minWait) / 2;

                Replace(grid, pivot);
                
                if (!IsConnected(grid, pivot))
                {
                    minWait = pivot + 1;
                }
                else
                {
                    maxWait = pivot;
                    Reset(grid, pivot, minWait);
                }
            }

            return maxWait;
        }

        private void Reset(int[][] grid, int pivot, int minWait)
        {
            var n = grid.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == pivot)
                    {
                        grid[i][j] = minWait;
                    }
                }
            }
        }

        private bool IsConnected(int[][] grid, int pivot)
        {
            var n = grid.Length;
            var start = new Tuple<int, int>(0, 0);

            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(start);
            var visited = new HashSet<Tuple<int, int>>();
            
            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                visited.Add(top);
                if (top.Item1 == n - 1 && top.Item2 == n - 1)
                {
                    return true;
                }

                var neighbors = GetNeighbors(top.Item1, top.Item2, grid);

                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor) && grid[neighbor.Item1][neighbor.Item2] == pivot)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return false;
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
            return row >= 0 && col >= 0 && row < grid.Length && col < grid.Length;
        }

        private void Replace(int[][] grid, int pivot)
        {
            var n = grid.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] <= pivot)
                    {
                        grid[i][j] = pivot;
                    }
                }
            }
        }

        // brute force
    }
}
