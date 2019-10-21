using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC490_Maze
{
    [TestClass]
    public class MazeTests
    {
        [TestMethod]
        // both dfs
        // use dfs to find path, use bfs to find all possible path
        public void GivenGridAndValidStartPointAndEndPoint_FindPath_ShouldReturnTrue()
        {
            var grid = new int[][] { new int[] {0, 0, 1, 0},
                                     new int[] {0, 1, 0, 0},
                                     new int[] {0, 1, 0, 0},
                                     new int[] {0, 0, 0, 1}};

            var startRow = 0; var startCol = 0;
            var endRow = 1; var endCol = 0;


            var result = FindPath(grid, startRow, startCol, endRow, endCol);

            Assert.IsTrue(result);
        }

        [TestMethod]
        // see if all 0s are connected, start with endPoint and use bfs to mark all 0s as visited
        // if by the end of the queue, there are still un-visited then false
        public void GivenValidGridAndEndPoint_FindCanReachEndPoint_ShouldReturnTrue()
        {
            var grid = new int[][] { new int[] {0, 0, 1, 0},
                                     new int[] {0, 1, 0, 0},
                                     new int[] {0, 1, 0, 0},
                                     new int[] {0, 0, 0, 1}};

            var endRow = 1; var endCol = 0;

            var result = CanReachEndPoint(grid, endRow, endCol);

            Assert.IsTrue(result);
        }

        [TestMethod]
        // see if all 0s are connected, start with endPoint and use bfs to mark all 0s as visited
        // if by the end of the queue, there are still un-visited then false
        public void GivenValidGridInValidEndPoint_FindCanReachEndPoint_ShouldReturnTrue()
        {
            var grid = new int[][] { new int[] {0, 0, 1, 0},
                                     new int[] {0, 0, 0, 0},
                                     new int[] {1, 1, 0, 0},
                                     new int[] {0, 1, 0, 1}};

            var endRow = 0; var endCol = 3;

            var result = CanReachEndPoint(grid, endRow, endCol);

            Assert.IsFalse(result);
        }

        private bool CanReachEndPoint(int[][] grid, int endRow, int endCol)
        {
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(endRow, endCol));
            var row = grid.Length;
            var col = grid[0].Length;

            var visited = GenerateVisitedMatrix(row, col);
            
            while (queue.Count != 0)
            {
                var coor = queue.Dequeue();
                visited[coor.Item1][coor.Item2] = true; // mark as visited

                var neighbors = GetNeighbors(grid, visited, coor.Item1, coor.Item2);
                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!visited[i][j] && grid[i][j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool FindPath(int[][] grid, int startRow, int startCol, int endRow, int endCol)
        {
            // 
            var row = grid.Length;
            var col = grid[0].Length;

            var visited = GenerateVisitedMatrix(row, col);

            return FindPathDFS(grid, visited, startRow, startCol, endRow, endCol);
        }

        private bool FindPathDFS(int[][] grid, bool[][] visited, int currRow, int currCol, int endRow, int endCol)
        {
            if (currRow == endRow && currCol == endCol)
            {
                return true;
            }

            visited[currRow][currCol] = true;

            var neighbors = GetNeighbors(grid, visited, currRow, currCol);

            foreach(var neighbor in neighbors)
            {
                if (FindPathDFS(grid, visited, neighbor.Item1, neighbor.Item2, endRow, endCol))
                {
                    return true;
                }
            }

            return false;
        }

        private bool[][] GenerateVisitedMatrix(int row, int col)
        {
            var visited = new bool[row][];
            for (int i = 0; i < row; i++)
            {
                visited[i] = new bool[col];
            }

            return visited;
        }

        private List<Tuple<int, int>> GetNeighbors(int[][] grid, bool[][] visited, int row, int col)
        {
            var neighbors = new List<Tuple<int, int>>();

            if (CanMoveTo(grid, visited, row - 1, col)) // left 
            {
                neighbors.Add(new Tuple<int, int>(row - 1, col));
            }

            if (CanMoveTo(grid, visited, row + 1, col)) //right
            {
                neighbors.Add(new Tuple<int, int>(row + 1, col));
            }

            if (CanMoveTo(grid, visited, row, col - 1)) // up 
            {
                neighbors.Add(new Tuple<int, int>(row, col - 1));
            }

            if (CanMoveTo(grid, visited, row, col + 1)) // down
            {
                neighbors.Add(new Tuple<int, int>(row, col + 1));
            }

            return neighbors;
        }

        private bool CanMoveTo(int[][] grid, bool[][] visited, int row, int col)
        {
            return row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == 0 && !visited[row][col];
        }
    }
}
