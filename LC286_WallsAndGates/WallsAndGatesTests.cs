using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC286_WallsAndGates
{
    [TestClass]
    public class WallsAndGatesTests
    {
        [TestMethod]
        public void GivenGridWallsRoomsAndGates_MapRoom_ShouldGenerateCorrectMatrix()
        {
            var grid = new int[][] { new int[] { int.MaxValue, -1, 0, int.MaxValue },
                                      new int[] { int.MaxValue, int.MaxValue, int.MaxValue, -1 },
                                      new int[] { int.MaxValue, -1, int.MaxValue, -1 },
                                      new int[] { 0, -1, int.MaxValue, int.MaxValue }};


            var result = MapRoom(grid);

            Assert.IsTrue(result[0].SequenceEqual(new int[] { 3, -1,  0,  1 }));
            Assert.IsTrue(result[1].SequenceEqual(new int[] { 2,  2,  1, -1 }));
            Assert.IsTrue(result[2].SequenceEqual(new int[] { 1, -1,  2, -1 }));
            Assert.IsTrue(result[3].SequenceEqual(new int[] { 0, -1,  3,  4 }));
        }

        private int[][] MapRoom(int[][] grid)
        {
            var queue = GetGates(grid);

            while (queue.Count != 0)
            {
                var room = queue.Dequeue();

                if (grid[room.Item1][room.Item2] > room.Item3)
                {
                    grid[room.Item1][room.Item2] = room.Item3;
                }

                var neighbors = GetNeighbors(room, grid);

                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }

            return grid;
        }

        private List<Tuple<int, int, int>> GetNeighbors(Tuple<int, int, int> parent, int[][] grid)
        {
            var row = parent.Item1;
            var col = parent.Item2;
            var value = parent.Item3 + 1;
            var neighbors = new List<Tuple<int, int, int>>();
            if (CanMoveTo(row - 1, col, grid))
            {
                neighbors.Add(new Tuple<int, int, int>(row - 1, col, value));    
            }
            if (CanMoveTo(row + 1, col, grid))
            {
                neighbors.Add(new Tuple<int, int, int>(row + 1, col, value));
            }
            if (CanMoveTo(row, col - 1, grid))
            {
                neighbors.Add(new Tuple<int, int, int>(row, col - 1, value));
            }
            if (CanMoveTo(row, col + 1, grid))
            {
                neighbors.Add(new Tuple<int, int, int>(row, col + 1, value));
            }

            return neighbors;
        }

        private bool CanMoveTo(int row, int col, int[][] grid)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == int.MaxValue;
        }

        private Queue<Tuple<int, int, int>> GetGates(int[][] grid)
        {
            var queue = new Queue<Tuple<int, int, int>>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        queue.Enqueue(new Tuple<int, int, int>(i, j, 0));
                    }
                }
            }

            return queue;
        }
    }
}
