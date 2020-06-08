using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC934_ShortestBridge
{
    [TestClass]
    public class ShortestBridgeTests
    {
        [TestMethod]
        public void GivenGridAndTwoIslands_FindShortestPath_ShouldReturnShortestLength()
        {
            var grid = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
            var result = FindShortestPath(grid);

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void GivenAnotherGridAndTwoIslands_FindShortestPath_ShouldReturnShortestLength()
        {
            var grid = new int[][] { new int[] { 0, 1, 0 },
                                     new int[] { 0, 0, 0 },
                                     new int[] { 0, 0, 1 }};

            var result = FindShortestPath(grid);

            Assert.IsTrue(result == 2);
        }

        private int FindShortestPath(int[][] grid)
        {
            var visited = new HashSet<(int r, int c)>();
            var coor = FindFirstIsland(grid);

            var queue = MapIslandPerimeter(grid, coor, visited);

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();

                var neighbors = GetNeighbors(top.r, top.c, grid);
                foreach (var neighbor in neighbors)
                {
                    if (grid[neighbor.r][neighbor.c] == 0)
                    {
                        grid[neighbor.r][neighbor.c] = 1;
                        queue.Enqueue((neighbor.r, neighbor.c, top.d + 1));
                        visited.Add((neighbor.r, neighbor.c));
                    }
                    else if (grid[neighbor.r][neighbor.c] == 1 && !visited.Contains((neighbor.r, neighbor.c)))
                    {
                        // found next island
                        return top.d;
                    }
                }
            }

            return -1;
        }

        private Queue<(int r, int c, int d)> AddFirstIslandToQueue(HashSet<(int r, int c)> visited)
        {
            var queue = new Queue<(int r, int c, int d)>();
            foreach (var coor in visited)
            {
                queue.Enqueue((coor.r, coor.c, 0));
            }

            return queue;
        }

        private Queue<(int r, int c, int d)> MapIslandPerimeter(int[][] grid, (int r, int c) coor, HashSet<(int r, int c)> visited)
        {
            var queue = new Queue<(int r, int c)>();
            var perimeter = new Queue<(int r, int c, int d)>();
            queue.Enqueue(coor);

            while (queue.Count != 0)
            {
                var top = queue.Dequeue();
                visited.Add(top);

                var neighbors = GetNeighbors(top.r, top.c, grid);

                if (neighbors.Any(x => grid[x.r][x.c] == 0))
                {
                    perimeter.Enqueue((top.r, top.c, 0));
                }

                foreach(var neighbor in neighbors)
                {
                    if(grid[neighbor.r][neighbor.c] == 1 && !visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return perimeter;
        }

        private List<(int r, int c)> GetNeighbors( int r, int c, int[][] grid)
        {
            var result = new List<(int r, int c)>();

            if (CanMove(r - 1, c, grid))
            {
                result.Add((r - 1, c));
            }

            if (CanMove(r + 1, c, grid))
            {
                result.Add((r + 1, c));
            }

            if (CanMove(r, c - 1, grid))
            {
                result.Add((r, c - 1));
            }

            if (CanMove(r, c + 1, grid))
            {
                result.Add((r, c + 1));
            }
            return result;
        }

        private bool CanMove(int r, int c, int[][] grid)
        {
            return r >= 0 && c >= 0 && r < grid.Length && c < grid[0].Length;
        }

        private (int r, int c) FindFirstIsland(int[][] grid)
        {
            for(int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return (i, j);
                    }
                }

            }

            return (-1, -1);
        }
    }
}
